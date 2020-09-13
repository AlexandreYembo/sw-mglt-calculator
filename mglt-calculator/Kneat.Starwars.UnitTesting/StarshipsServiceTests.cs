using Kneat.Starwars.Repositories.Interfaces;
using Kneat.Starwars.Services;
using Kneat.Starwars.Services.Interfaces;
using Kneat.Starwars.UnitTesting.Stub;
using Moq;
using Moq.AutoMock;
using Xunit;

namespace Kneat.Starwars.UnitTesting
{
    public class StarshipsServiceTests
    {
        private readonly AutoMocker _mocker;
        private readonly Mock<IMGLTCalculatorService> _mgltCalculatorService;
        private readonly Mock<IStarshipsRepository> _starshipsRepository;
        private readonly IStarshipsService _starshipService;


        public StarshipsServiceTests()
        {
            _mocker = new AutoMocker();
            _starshipsRepository = _mocker.GetMock<IStarshipsRepository>();

            _mgltCalculatorService = _mocker.GetMock<IMGLTCalculatorService>();
            _starshipService = _mocker.CreateInstance<StarshipsService>();
        }
        [Fact(DisplayName="Should get the starship with the Stop calculated")]
        [Trait("Starship", "Get Starship and Calculate the stops")]
        public void Starship_ShouldGetStarship_ReturnHowManyStops()
        {
            //Arrange
            double input = 1000000;

           
            var sub = new StarshipResponseStub().GetOne();
            _starshipsRepository.Setup(s => s.GetAllStarshipsAsync(1)).ReturnsAsync(sub);

            _mgltCalculatorService.Setup(s => s.CalculateStopsByDistance(input, sub.Results[0].Consumables, sub.Results[0].MGLT))
                                  .Returns(9);

            //Act
            var result = _starshipService.GetAllStarShipsAndAddStop(input);

            //Assert
            Assert.Equal(9, result.Result[0].Stops);
        }
    }
}