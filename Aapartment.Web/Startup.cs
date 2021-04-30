using Aapartment.Business.Config;
using Aapartment.Business.Constants;
using Aapartment.Business.Exceptions;
using Aapartment.Business.SeedInterfaces;
using Aapartment.Business.SeedServices;
using Aapartment.Business.ServiceInterfaces;
using Aapartment.Business.Services;
using Aapartment.Dal;
using Aapartment.Dal.Entities;
using Aapartment.Web.Mail;
using Aapartment.Web.Refit;
using Hellang.Middleware.ProblemDetails;
using Hellang.Middleware.ProblemDetails.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Aapartment.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AapartmentDbContext>(
                o => o.UseSqlServer(Configuration.GetConnectionString(nameof(AapartmentDbContext))));

            services.AddIdentity<User, IdentityRole<int>>()
                .AddEntityFrameworkStores<AapartmentDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 8;

                opts.SignIn.RequireConfirmedEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/access-denied";
                options.LoginPath = "/login";
                options.LogoutPath = "/logout";
            });

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = System.TimeSpan.FromMinutes(5);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdministratorRole", policy => policy.RequireRole(Roles.Admin));
            });

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddAuthentication().AddFacebook(facebookOptions =>
            {
                facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
                facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
            }).AddCookie(p => p.SlidingExpiration = true);

            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddCors(policy =>
            {
                policy.AddPolicy("CorsPolicy", opt => opt
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());
            });

            services.AddAutoMapper(typeof(MapProfile));

            services.AddScoped<IRoleSeedService, RoleSeedService>()
                    .AddScoped<IAdminSeedService, AdminSeedService>();

            services.AddScoped<IApartmentService, ApartmentService>()
                    .AddScoped<IBookingService,BookingService>()
                    .AddScoped<IReviewService, ReviewService>()
                    .AddScoped<IRoomService, RoomService>()
                    .AddScoped<IUserService, UserService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Aapartment API",
                    Description = "Webportálok 2021",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Surmann Roland",
                        Email = "surmannroland@gmail.com"
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://example.com/license"),
                    }
                });
                // Set the comments path for the Swagger JSON and UI.
                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);
            });
            services.AddControllers();
            services.AddControllersWithViews();

            services
                .AddRefitClient<IApartmentsApi>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(@"http://localhost:41873/api/apartments"));

            services
                .AddRefitClient<IRoomsApi>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(@"http://localhost:41873/api/rooms"));

            services
                .AddRefitClient<IReviewsApi>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(@"http://localhost:41873/api/reviews"));

            services.AddHttpClient("base", c =>
            {
                c.BaseAddress = new Uri("http://localhost:41873");
            });

            services.AddProblemDetails(ConfigureProblemDetails)
                .AddControllers()
                .AddProblemDetailsConventions()
                .AddJsonOptions(x => x.JsonSerializerOptions.IgnoreNullValues = true);
            

            services.AddRazorPages(options => {
                options.Conventions.AuthorizeFolder("/AdminSitePages", "RequireAdministratorRole");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseCookiePolicy();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseProblemDetails();

            app.UseCors("CorsPolicy");

            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Aapartment");
                c.RoutePrefix = "swagger";
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
        private void ConfigureProblemDetails(ProblemDetailsOptions options)
        {
            options.MapToStatusCode<DbNullException>(StatusCodes.Status404NotFound);
            options.MapToStatusCode<QueryParamsNullException>(StatusCodes.Status400BadRequest);
        }
        
    }
}
