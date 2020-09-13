using System;
using System.IO;
using Kneat.Starwars.Console.DependencyInjection;
using Kneat.Starwars.Services.TimeCalculation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kneat.Starwars.Console
{
    public static class Startup
    {
        public static IConfigurationRoot configuration;

        public static void Main(IServiceCollection services)
        {
           // Build configuration
        configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
            .AddJsonFile("appsettings.json", false)
            .Build();

            services.AddSingleton<IConfiguration>(provider => configuration);
            
            services.RegisterToServices();
            services.RegisterToRepositories();
            services.RegisterToInfrastructure();
            services.RegisterToConsumables();
            
        }
    }
}