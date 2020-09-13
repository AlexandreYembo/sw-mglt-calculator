using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kneat.Starwars.Repositories.Models;

namespace Kneat.Starwars.Services.Interfaces
{
    /// <summary>
    /// Interface that implements the Starship service
    /// </summary>
    public interface IStarshipsService : IDisposable
    {
        Task<List<Starships>> GetAllStarShipsAndAddStop(double distance);
    }
}