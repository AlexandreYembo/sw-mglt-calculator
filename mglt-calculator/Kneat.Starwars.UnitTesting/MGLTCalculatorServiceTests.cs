using Xunit;
using Moq.AutoMock;
using Kneat.Starwars.Services;
using Kneat.Starwars.Services.TimeCalculation;
using Kneat.Starwars.Services.Interfaces;

namespace Kneat.Starwars.UnitTesting
{
    public class MGLTCalculatorServiceTests
    {
        private readonly AutoMocker _mocker;
        private readonly MGLTCalculatorService _mgltCalculatorService;

        public MGLTCalculatorServiceTests()
        {
            _mocker = new AutoMocker();
            _mgltCalculatorService = _mocker.CreateInstance<MGLTCalculatorService>();
        }
        [Fact(DisplayName="Should Calculate Stops By Distance and Months")]
        [Trait("MGLT", "Stops Calculation")]
        public void MGLTStops_ShouldCalculateStopByDistanceAndMonths()
        {
            //Arrange
            var hourPerMonth = 730;
            var input = 1000000;
            _mocker.GetMock<IHoursCalculation>().Setup(s => s.GetHours()).Returns(hourPerMonth);
            _mocker.GetMock<IConvertConsumableService>().Setup(s => s.ToHour(2, "months")).Returns(hourPerMonth * 2);

            //Act
            var result = _mgltCalculatorService.CalculateStopsByDistance(input, "2 months", "75");

            //Assert
            Assert.Equal(9, result);
        }

        [Fact(DisplayName="Should not Calculate Stops By Unknown MGLT")]
        [Trait("MGLT", "Stops Calculation")]
        public void MGLTStops_ShouldNotCalculateStopByUnknowMGLT()
        {
            //Arrange
            var input = 1000000;
            //Act
            var result = _mgltCalculatorService.CalculateStopsByDistance(input, "unknow", "unknow");

            //Assert
            Assert.Equal(0, result);
        }

         [Fact(DisplayName="Should not Calculate Stops By Unknown Consumable")]
        [Trait("MGLT", "Stops Calculation")]
        public void MGLTStops_ShouldNotCalculateStopByUnknowConsumable()
        {
            //Arrange
            var hourPerMonth = 730;
            var input = 1000000;
            _mocker.GetMock<IHoursCalculation>().Setup(s => s.GetHours()).Returns(hourPerMonth);
            _mocker.GetMock<IConvertConsumableService>().Setup(s => s.ToHour(0, "unknown")).Returns(hourPerMonth * 2);

            //Act
            var result = _mgltCalculatorService.CalculateStopsByDistance(input, "unknown", "70");

            //Assert
            Assert.Equal(0, result);
        }
    }
}