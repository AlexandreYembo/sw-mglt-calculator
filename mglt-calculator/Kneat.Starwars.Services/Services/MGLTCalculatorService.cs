using System;
using Kneat.Starwars.Services.Interfaces;

namespace Kneat.Starwars.Services
{
    /// <summary>
    /// Calculator class for MGLT
    /// </summary>
    public class MGLTCalculatorService : IMGLTCalculatorService
    {
        public readonly IConvertConsumableService _convertConsumable;

        public MGLTCalculatorService(IConvertConsumableService convertConsumable)
        {
            _convertConsumable = convertConsumable;
        }

        /// <summary>
        /// Method that retuns how many stops by a defined distance
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="consumables"></param>
        /// <param name="mglt"></param>
        /// <returns></returns>
        public double CalculateStopsByDistance(double distance, string consumables, string mglt)
        {
            double megaLights = 0;
            double.TryParse(mglt, out megaLights);

            if(megaLights == 0 || consumables == "unknown")
                return 0;
                
            var hours = GetHours(distance, megaLights);
            var consumablesHours = ConvertCosumablesToHours(consumables);
            var stops = consumablesHours == 0 ? consumablesHours : hours / consumablesHours;
            return Math.Floor(stops);
        }

        /// <summary>
        /// Get hours by distance devide by megaLights
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="megaLights"></param>
        /// <returns></returns>
        private double GetHours(double distance, double megaLights) => distance / megaLights;

        /// <summary>
        /// Get Consumable hours per Starship
        /// </summary>
        /// <param name="consumables"></param>
        /// <returns></returns>
        private double ConvertCosumablesToHours(string consumables)
        {
            var consumablesArr = consumables.Split(' ');
            double number = Double.Parse(consumablesArr[0]);
            
            string time = consumablesArr[1];
            return _convertConsumable.ToHour(number, time);
        }
    }
}