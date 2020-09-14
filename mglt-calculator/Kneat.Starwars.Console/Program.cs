using System;
using System.Threading.Tasks;
using Kneat.Starwars.Console.Composite;
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

            System.Console.WriteLine("Hello, welcome to the Starwars Universe. Please provide the distance you want for calculating the number of stops you will need for the Starships!");

            System.Console.WriteLine("Inform the Distance:");
            var distance = int.Parse(System.Console.ReadLine());
            
            var starships =  await starshipsService.GetAllStarShipsAndAddStop(distance);
            
            var message = new Message("Wow, here are all starships for this voyage!", '#');

            foreach (var result in starships)
            {
                var starship = new Message(result.Name, '>');
                starship.AddChild(new Message($"Model: { result.Model }"));
                starship.AddChild(new Message($"Manufacturer: { result.Manufacturer }"));
                starship.AddChild(new Message($"Number of stops: { result.Stops }"));
                message.AddChild(starship);
            }

            message.DisplayMessages(2);

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
