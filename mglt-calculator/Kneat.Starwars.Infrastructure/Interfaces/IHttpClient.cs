using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Kneat.Starwars.Infrastructure.Interfaces
{
    /// <summary>
    /// Interface used to implement HttpClientWrap class and used to create MOQ objects for Unit test
    /// </summary>
    public interface IHttpClient : IDisposable
    {
         Task<HttpResponseMessage> GetAsync(string requestUri);
    }
}