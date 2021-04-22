using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aapartment.Web.Hosting;

namespace Aapartment.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            (await CreateHostBuilder(args)
                .Build()
                .MigrateDatabaseAsync<Aapartment.Dal.AapartmentDbContext>())
                .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
