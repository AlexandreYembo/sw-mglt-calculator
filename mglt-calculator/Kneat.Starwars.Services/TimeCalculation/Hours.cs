using System;

namespace Kneat.Starwars.Services.TimeCalculation
{
    /// <summary>
    /// Base class that returns the hours
    /// </summary>
    public class Hours : IHours
    {
        /// <summary>
        /// Get hours based on the day parameter.
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        public double Get(int days) => new TimeSpan(days, 0, 0, 0).TotalHours;
    }
}