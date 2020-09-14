using System;
using Kneat.Starwars.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Kneat.Starwars.IntegrationTest.Config
{
    /// <summary>
    /// Collection will apply for all test class that are member of this collection. You have to declare this collection
    /// as attribute of the Test Class
    /// </summary>
    [CollectionDefinition(nameof(IntegrationTestsFixtureCollection))]
    public class IntegrationTestsFixtureCollection: ICollectionFixture<IntegrationTestsFixture>{ }

    /// <summary>
    /// This fixture created once the instance of objects and it does not call for each test that starts, 
    /// because it saves the state of the object.
    /// </summary>    
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