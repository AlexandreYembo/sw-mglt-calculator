using System;
using System.Threading.Tasks;
using Kneat.Starwars.Services;
using Kneat.Starwars.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Kneat.Starwars.Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serviceCollection = RegisterStartup();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var starshipsService = serviceProvider.GetService<IStarshipsService>();

            System.Console.WriteLine("Hello, welcome to the Starwars Universe. Please provide the distance you want for calculating how many stops you will need for the Starships!");

            System.Console.WriteLine("Inform the Distance:");
            var distance = int.Parse(System.Console.ReadLine());
            
            var starships =  await starshipsService.GetAllStarShipsAndAddStop(distance);
            
            foreach (var result in starships)
            {
                System.Console.WriteLine(result.Name + "=" + result.Stops);
            }

            starshipsService.Dispose();
        }

        private static ServiceCollection RegisterStartup()
        {
            var serviceCollection = new ServiceCollection();
            Startup.Main(serviceCollection);

            return serviceCollection;
        }
    }
}
