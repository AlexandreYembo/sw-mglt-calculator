using System;
using Kneat.Starwars.Services.TimeCalculation;
using Microsoft.Extensions.DependencyInjection;

namespace Kneat.Starwars.Console.DependencyInjection
{
    public static class RegisterConsumables
    {
         public static void RegisterToConsumables(this IServiceCollection services)
         {
             services.AddTransient<Func<string, IHoursCalculation>>(serviceProvider => timeType =>
            {
                switch (timeType.ToUpper())
                {
                    case "DAY":  
                    case "DAYS":  
                        return serviceProvider.GetService<HoursPerDay>();       // Consumable per Days
                    case "WEEK": 
                    case "WEEKS": 
                        return serviceProvider.GetService<HoursPerWeek>();      // Consumable per Week
                    case "MONTH":
                    case "MONTHS":
                        return serviceProvider.GetService<HoursPerMonth>();     // Consumable per Month
                    case "YEAR":
                    case "YEARS":
                        return serviceProvider.GetService<HoursPerYear>();      // consumable per Year
                    default:
                        return serviceProvider.GetService<UnknowTime>();        // Consumable not defined
                }
            });
         }
    }
}