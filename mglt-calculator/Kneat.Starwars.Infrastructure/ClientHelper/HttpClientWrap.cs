using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Kneat.Starwars.Infrastructure.Interfaces;

namespace Kneat.Starwars.Infrastructure.ClientHelper
{
    /// <summary>
    /// Class that wrap the HttpClient and implements an interface.
    /// It can help to implement unit test by implementing Mock<IHttpClient>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HttpClientWrap : IHttpClient
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Create the HttpClient object
        /// </summary>
        public HttpClientWrap()
        {
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// make get request to an endpoint
        /// </summary>
        /// <param name="requestUri"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetAsync(string requestUri) => await _httpClient.GetAsync(requestUri);

        /// <summary>
        /// Destroy the httpClient object
        /// </summary>
        public void Dispose() => _httpClient.Dispose();
    }
}