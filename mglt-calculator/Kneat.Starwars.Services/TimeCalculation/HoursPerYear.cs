namespace Kneat.Starwars.Services.TimeCalculation
{
    /// <summary>
    /// Implements the interface IHourCalculation and Get hour per year.
    /// </summary>
    public class HoursPerYear : IHoursCalculation
    {
        protected readonly IHours _hours;

        /// <summary>
        /// Constructor that implements the interface IHour.
        /// </summary>
        /// <param name="hours"></param>
        public HoursPerYear(IHours hours)
        {
            this._hours = hours;
        }

        /// <summary>
        /// Get hours, define as parameter 365 days = 1 year.
        /// </summary>
        /// <returns></returns>
        public double GetHours() => _hours.Get(365);
    }
}