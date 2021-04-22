using Aapartment.Business.Config;
using Aapartment.Business.SeedInterfaces;
using Aapartment.Business.SeedServices;
using Aapartment.Business.ServiceInterfaces;
using Aapartment.Business.Services;
using Aapartment.Dal;
using Aapartment.Dal.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
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

            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.LoginPath = "/Identity/Account/Login";
                options.LogoutPath = "/Identity/Account/Logout";
            });

            services.AddAutoMapper(typeof(MapProfile));

            services.AddScoped<IRoleSeedService, RoleSeedService>()
                    .AddScoped<IAdminSeedService, AdminSeedService>();

            services.AddScoped<IApartmentService, ApartmentService>()
                    .AddScoped<IBookingService,BookingService>()
                    .AddScoped<IReviewService, ReviewService>()
                    .AddScoped<IRoomService, RoomService>()
                    .AddScoped<IUserService, UserService>();

            services.AddControllers();

            services.AddRazorPages();
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

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
