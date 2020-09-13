using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kneat.Starwars.Infrastructure.Interfaces;
using Kneat.Starwars.Repositories.Interfaces;
using Kneat.Starwars.Repositories.Models;

namespace Kneat.Starwars.Infrastructure.Repositories
{
    /// <summary>
    /// Class repository responsible to get the object via API Request.
    /// This class implements the interface IStarshipsRepository and could be replaced for another Repository, such Database or File source.
    /// </summary>
    public class StarshipsRepository : IStarshipsRepository, IDisposable
    {
        protected readonly IApiClient _api;

        /// <summary>
        /// Inject the proxy via Dependency injection
        /// </summary>
        /// <param name="api"></param>
        public StarshipsRepository(IApiClient api)
        {
            _api = api;
        }

        /// <summary>
        /// asynchronous method used to get all Starships
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        public async Task<StarshipResponse> GetAllStarshipsAsync(int pagination){
            var response = await _api.GetAsync<StarshipResponse>($"starships/?page={pagination}");
            return response;
        }

        /// <summary>
        /// Dispose the proxy object
        /// </summary>
        public void Dispose()
        {
            _api.Dispose();
        }
    }
}