using Kneat.Starwars.Services.TimeCalculation;
using Xunit;

namespace Kneat.Starwars.UnitTesting
{
    public class HourCalculatorTests
    {
        private IHoursCalculation _hoursCalculation;
        
        [Fact(DisplayName="Should Get Hours per day")]
        [Trait("Hours", "Hours Calculation")]
        public void HoursCalculation_ShouldGetHoursPerDay()
        {
            //Arrange
            _hoursCalculation = new HoursPerDay(new Hours());
            //Act
            var result = _hoursCalculation.GetHours();
            //Assert
            Assert.Equal(24, result);
        }

        [Fact(DisplayName="Should Get Hours per week")]
        [Trait("Hours", "Hours Calculation")]
        public void HoursCalculation_ShouldGetHoursPerWeek()
        {
            //Arrange
            _hoursCalculation = new HoursPerWeek(new Hours());
            //Act
            var result = _hoursCalculation.GetHours();
            //Assert
            Assert.Equal(168, result);
        }

        [Fact(DisplayName="Should Get Hours per month")]
        [Trait("Hours", "Hours Calculation")]
        public void HoursCalculation_ShouldGetHoursPerMonth()
        {
            //Arrange
            _hoursCalculation = new HoursPerMonth(new Hours());
            //Act
            var result = _hoursCalculation.GetHours();
            //Assert
            Assert.Equal(730, result);
        }

        [Fact(DisplayName="Should Get Hours per year")]
        [Trait("Hours", "Hours Calculation")]
        public void HoursCalculaton_ShouldGetHoursPerYear()
        {
            //Arrange
            _hoursCalculation = new HoursPerYear(new Hours());
            //Act
            var result = _hoursCalculation.GetHours();
            //Assert
            Assert.Equal(8760, result);
        }

        [Fact(DisplayName="Should Not Get Hours per year")]
        [Trait("Hours", "Hours Calculation")]
        public void HoursCalcualtion_ShouldNotGetHours()
        {
            //Arrange
            _hoursCalculation = new UnknowTime(new Hours());
            //Act
            var result = _hoursCalculation.GetHours();
            //Assert
            Assert.Equal(0, result);
        }
    }
}
