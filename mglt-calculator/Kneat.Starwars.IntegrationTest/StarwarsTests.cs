using System.Linq;
using System.Threading.Tasks;
using Kneat.Starwars.IntegrationTest.Config;
using Kneat.Starwars.Services.Interfaces;
using Xunit;

namespace Kneat.Starwars.IntegrationTest
{
    [Collection(nameof(IntegrationTestsFixtureCollection))]
    public class StarwarsTests
    {
        private readonly IntegrationTestsFixture _test_Fixture;
        private readonly IStarshipsService _starshipService;

        public StarwarsTests(IntegrationTestsFixture textFixture)
        {
            _test_Fixture = textFixture;
            _starshipService = _test_Fixture._starshipService;
        }
        [Fact(DisplayName="Get Stop for starships")]
        [Trait("Starships", "Should Get the starships and calculate how many stops for each one")]
        public async Task Starships_ShouldGetStarShips_CalculateStopsForEachStarships()
        {
            //Arrange
            var input = _test_Fixture.GetInput();

            //Act
            var starships = await _starshipService.GetAllStarShipsAndAddStop(input);

            //Assert
            Assert.True(starships.Count > 0);
            Assert.True(starships.Any(a => a.Stops > 0));
        }
    }
}