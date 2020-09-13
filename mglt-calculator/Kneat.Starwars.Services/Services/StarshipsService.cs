using System.Collections.Generic;
using System.Threading.Tasks;
using Kneat.Starwars.Repositories.Interfaces;
using Kneat.Starwars.Repositories.Models;
using Kneat.Starwars.Services.Interfaces;

namespace Kneat.Starwars.Services
{
    /// <summary>
    /// Startship service is the main Service that has many roles.
    /// 1- Get a list of starships and apply calculate and apply count of stops for each starship configuration.
    /// </summary>
    public class StarshipsService : IStarshipsService
    {
        protected readonly IStarshipsRepository _repository;
        protected readonly IMGLTCalculatorService _calculatorService;

        public StarshipsService(IStarshipsRepository repository, IMGLTCalculatorService calculatorService)
        {
            _repository = repository;
            _calculatorService = calculatorService;
        }

        public async Task<List<Starships>> GetAllStarShipsAndAddStop(double distance)
        {
            int pagination = 0;
            var starships = new List<Starships>();

            var response = new StarshipResponse(){ Next = "" };
            while(response.Next != null){
                response = await _repository.GetAllStarshipsAsync(++pagination);
                starships.AddRange(response.Results);
            }
            
            ApplyStopsToStartship(starships, distance);
               
            return starships;
        }

        /// <summary>
        /// Apply count of stops per starship
        /// </summary>
        /// <param name="starships"></param>
        private void ApplyStopsToStartship(List<Starships> starships, double distance) => starships.ForEach(f => f.AddStops(_calculatorService.CalculateStopsByDistance(distance, f.Consumables, f.MGLT)));

        /// <summary>
        /// Dispose the repository object
        /// </summary>
        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}