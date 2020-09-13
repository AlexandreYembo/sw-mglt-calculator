using System;
using System.Threading.Tasks;

namespace Kneat.Starwars.Infrastructure.Interfaces
{
    /// <summary>
    /// Interface used to implement proxy concrete class to comunicate the client api through the API
    /// </summary>
    public interface IApiClient : IDisposable
    {
         Task<T> GetAsync<T>(string resource);
    }
}