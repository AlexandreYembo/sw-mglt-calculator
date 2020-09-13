using System;

namespace Kneat.Starwars.Services.TimeCalculation
{
    /// <summary>
    /// Implements the interface IHourCalculation and Get hour per week.
    /// </summary>
    public class HoursPerWeek : IHoursCalculation
    {
        protected readonly IHours _hours;

        /// <summary>
        /// Constructor that implements the interface IHour.
        /// </summary>
        /// <param name="hours"></param>
        public HoursPerWeek(IHours hours)
        {
            this._hours = hours;
        }

        /// <summary>
        /// Get hours, define as parameter 7 days = 1 week.
        /// </summary>
        /// <returns></returns>
        public double GetHours() => _hours.Get(7);
    }
}