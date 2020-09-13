using Kneat.Starwars.Infrastructure.ClientHelper;
using Kneat.Starwars.Infrastructure.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Kneat.Starwars.IntegrationTest.DependencyInjection
{
    public static class RegisterInfrastructure
    {
        /// <summary>
        /// Register DI container for Infrastructure
        /// </summary>
        /// <param name="services"></param>
        public static void RegisterToInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IApiClient, ApiClient>();
            services.AddTransient<IHttpClient, HttpClientWrap>();
        }
    }
}