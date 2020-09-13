using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kneat.Starwars.Repositories.Models;

namespace Kneat.Starwars.Repositories.Interfaces
{
    /// <summary>
    /// Interface Repository used to implement in the concrete class of Infrastructure Layer.
    /// It can easily be replaced by another infrastructure such database or file source, etc.
    /// </summary>
    public interface IStarshipsRepository: IDisposable
    {
         Task<StarshipResponse> GetAllStarshipsAsync(int pagination);
    }
}