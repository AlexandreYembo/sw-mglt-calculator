namespace Kneat.Starwars.Services.TimeCalculation
{
    /// <summary>
    /// Implements the interface IHourCalculation and Get hour per day.
    /// </summary>
    public class HoursPerDay : IHoursCalculation
    {
        protected readonly IHours _hours;

        /// <summary>
        /// Constructor that implements the interface IHour.
        /// </summary>
        /// <param name="hours"></param>
        public HoursPerDay(IHours hours)
        {
            this._hours = hours;
        }

        /// <summary>
        /// Get hours, define as parameter 1 = 1 day
        /// </summary>
        /// <returns></returns>
        public double GetHours() => _hours.Get(1);
    }
}