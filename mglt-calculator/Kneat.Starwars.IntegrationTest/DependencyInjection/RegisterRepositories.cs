using Kneat.Starwars.Infrastructure.Repositories;
using Kneat.Starwars.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Kneat.Starwars.IntegrationTest.DependencyInjection
{
    public static class RegisterRepositories
    {
        /// <summary>
        /// Register DI container for Repositories
        /// </summary>
        /// <param name="services"></param>
        public static void RegisterToRepositories(this IServiceCollection services)
        {
            services.AddTransient<IStarshipsRepository, StarshipsRepository>();
        }
    }
}