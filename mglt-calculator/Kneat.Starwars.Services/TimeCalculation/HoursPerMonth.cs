namespace Kneat.Starwars.Services.TimeCalculation
{
    /// <summary>
    /// Implements the interface IHourCalculation and Get hour per month.
    /// </summary>
    public class HoursPerMonth : IHoursCalculation
    {
       protected readonly IHours _hours;

        /// <summary>
        /// Constructor that implements the interface IHour.
        /// </summary>
        /// <param name="hours"></param>
        public HoursPerMonth(IHours hours)
        {
            this._hours = hours;
        }

        /// <summary>
        /// Get hours, define as parameter take an AVG of 365 days divided by 12 months.
        /// </summary>
        /// <returns></returns>
        public double GetHours() => _hours.Get(365) / 12;
    }
}