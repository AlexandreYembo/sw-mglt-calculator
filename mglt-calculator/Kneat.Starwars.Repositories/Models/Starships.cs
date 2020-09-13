namespace Kneat.Starwars.Repositories.Models
{
    /// <summary>
    /// Model that presents the contract of Starship provided by the API or another source
    /// </summary>
    public class Starships
    {
        public string Name { get; set; }
        public string Consumables { get; set; }
        public string MGLT { get; set; }
        public double Stops { get; protected set; }

        /// <summary>
        /// Method to add stops for the Starship
        /// </summary>
        /// <param name="stops"></param>
        public void AddStops(double stops) => Stops = stops;
    }
}