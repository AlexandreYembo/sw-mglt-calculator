using System;
using System.IO;
using Kneat.Starwars.IntegrationTest.DependencyInjection;
using Kneat.Starwars.Services.TimeCalculation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kneat.Starwars.IntegrationTest.Config
{
    public class StarwarsStartup
    {
        public IConfigurationRoot configuration;

        public void Config(IServiceCollection services)
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

            services.AddTransient<Func<string, IHoursCalculation>>(serviceProvider => timeType =>
            {
                switch (timeType.ToUpper())
                {
                    case "DAY":  
                    case "DAYS":  
                        return serviceProvider.GetService<HoursPerDay>();
                    case "WEEK": 
                    case "WEEKS": 
                        return serviceProvider.GetService<HoursPerWeek>();
                    case "MONTH":
                    case "MONTHS":
                        return serviceProvider.GetService<HoursPerMonth>();
                    case "YEAR":
                    case "YEARS":
                        return serviceProvider.GetService<HoursPerYear>();
                    default:
                        return serviceProvider.GetService<UnknowTime>();
                }
            });
        }
    }
}