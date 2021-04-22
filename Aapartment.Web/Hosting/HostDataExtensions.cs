using Aapartment.Business.SeedInterfaces;
using Aapartment.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aapartment.Web.Hosting
{
    public static class HostDataExtensions
    {
        public async static Task<IHost> MigrateDatabaseAsync<TContext>(this IHost host) where TContext : AapartmentDbContext
        {
            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var context = serviceProvider.GetRequiredService<TContext>();
                context.Database.Migrate();

                var roleSeeder = serviceProvider.GetRequiredService<IRoleSeedService>();
                await roleSeeder.SeedRoleAsync();

                var adminSeeder = serviceProvider.GetRequiredService<IAdminSeedService>();
                await adminSeeder.SeedAdminAsync();

            }
            return host;
        }
    }

}
