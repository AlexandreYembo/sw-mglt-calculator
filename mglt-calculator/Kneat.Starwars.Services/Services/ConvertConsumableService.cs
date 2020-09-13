using System;
using Kneat.Starwars.Services.Interfaces;
using Kneat.Starwars.Services.TimeCalculation;

namespace Kneat.Starwars.Services
{
    /// <summary>
    /// This class is responsable to calculate the Consumable for each starship
    /// </summary>
    public class ConvertConsumableService : IConvertConsumableService
    {
        private readonly Func<string, IHoursCalculation> _hoursCalculation;

        /// <summary>
        /// Constructor implements a func.
        /// Note: This Func is setup on the Dependency Injection in Startup file. It means that there are multiple concrete class that implement
        /// this interface, and based on the type of time (day, week, month or year) it returns the proper calculation of hours.
        /// </summary>
        /// <param name="hoursCalculation"></param>
        public ConvertConsumableService(Func<string, IHoursCalculation> hoursCalculation)
        {
            _hoursCalculation = hoursCalculation;
        }

        /// <summary>
        /// Get the calculation by DI and multiply for the numbers of time.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="timeType"></param>
        /// <returns></returns>
        public double ToHour(double number, string timeType)
        {
            //Get the implementation from the dependency injection configuration by passibg timeType
            var instance = _hoursCalculation(timeType);
            var hours = instance.GetHours() * number;

            return hours;
        }
    }
}