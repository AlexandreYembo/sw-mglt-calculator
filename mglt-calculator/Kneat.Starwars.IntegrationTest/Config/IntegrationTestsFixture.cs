using System;
using Kneat.Starwars.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Kneat.Starwars.IntegrationTest.Config
{
    [CollectionDefinition(nameof(IntegrationTestsFixtureCollection))]
    public class IntegrationTestsFixtureCollection: ICollectionFixture<IntegrationTestsFixture>{ }
    
    public class IntegrationTestsFixture
    {
        
        public readonly IStarshipsService _starshipService;
        public readonly StarwarsStartup startup;
        public IntegrationTestsFixture()
        {
            var serviceCollection = new ServiceCollection();
            startup = new StarwarsStartup();
            startup.Config(serviceCollection);
            
            var serviceProvider = serviceCollection.BuildServiceProvider();
            _starshipService = serviceProvider.GetService<IStarshipsService>();
        }

        public int GetInput() => 1000000;
    }
}