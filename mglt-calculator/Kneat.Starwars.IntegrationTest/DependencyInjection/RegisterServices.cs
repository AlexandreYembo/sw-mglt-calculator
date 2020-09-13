using Kneat.Starwars.Services;
using Kneat.Starwars.Services.Interfaces;
using Kneat.Starwars.Services.TimeCalculation;
using Microsoft.Extensions.DependencyInjection;

namespace Kneat.Starwars.IntegrationTest.DependencyInjection
{
    public static class RegisterServices
    {
        public static void RegisterToServices(this IServiceCollection services)
        {
            services.AddTransient<IStarshipsService, StarshipsService>();
            services.AddTransient<IMGLTCalculatorService, MGLTCalculatorService>();
            services.AddTransient<IConvertConsumableService, ConvertConsumableService>();
            services.AddTransient<IHours, Hours>();
            services.AddTransient<HoursPerDay>();
            services.AddTransient<HoursPerWeek>();
            services.AddTransient<HoursPerMonth>();
            services.AddTransient<HoursPerYear>();
        }
    }
}