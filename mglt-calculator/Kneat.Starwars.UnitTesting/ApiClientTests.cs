using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Kneat.Starwars.Infrastructure.ClientHelper;
using Kneat.Starwars.Infrastructure.Interfaces;
using Kneat.Starwars.Repositories.Models;
using Kneat.Starwars.UnitTesting.Stub;
using Microsoft.Extensions.Configuration;
using Moq;
using Moq.AutoMock;
using Newtonsoft.Json;
using Xunit;

namespace Kneat.Starwars.UnitTesting
{
    public class ApiClientTests
    {
        private readonly AutoMocker _mocker;
        private readonly Mock<IHttpClient> _httpClient;
        private readonly Mock<IConfiguration> _configuration;
        private readonly Mock<IConfigurationSection> _configurationSection;

        private IApiClient _apiProxy;

        public ApiClientTests()
        {
            _mocker = new AutoMocker();
            _configurationSection = _mocker.GetMock<IConfigurationSection>();
            _configuration = _mocker.GetMock<IConfiguration>();

            _configurationSection.Setup(s => s.Value).Returns("http://localhost");
            
            _configuration.Setup(s => s.GetSection("api"))
                                             .Returns(_configurationSection.Object);
                                             
            _httpClient = _mocker.GetMock<IHttpClient>();
            _apiProxy = _mocker.CreateInstance<ApiClient>();
        }


        [Fact(DisplayName="Should get the starships and Return Sucess for status code")]
        [Trait("Api", "Get Starships")]
        public async Task Starship_ShouldGetStarships_ReturnSuccessStatusCode()
        {
            //Arrange
            var expectedStarship = new StarshipResponseStub().GetOne();
            var response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(new StarshipResponseStub().GetOne()), Encoding.UTF8, "application/json");            

            _httpClient.Setup(s => s.GetAsync(It.IsAny<string>()))
                       .ReturnsAsync(response);
            
            //Act
            var starships = await _apiProxy.GetAsync<StarshipResponse>("starships");
            //Assert
            Assert.True(starships.Results.Count > 0);
            Assert.Equal(expectedStarship.Results.Count, starships.Results.Count);
            Assert.Equal(expectedStarship.Results[0].Consumables, starships.Results[0].Consumables);
            Assert.Equal(expectedStarship.Results[0].MGLT, starships.Results[0].MGLT);
            Assert.Equal(expectedStarship.Results[0].Name, starships.Results[0].Name);
        }

        [Fact(DisplayName="Should not get the starships and Return not found for status code")]
        [Trait("Api", "Get Starships")]
        public async Task Starship_ShouldGetStarships_ReturnNotFoundStatusCode()
        {
            //Arrange
            var response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.NotFound);
            _httpClient.Setup(s => s.GetAsync(It.IsAny<string>()))
                       .ReturnsAsync(response);
            
            //Act
            var starships = await _apiProxy.GetAsync<StarshipResponse>("starships");
            //Assert
            Assert.False(starships != null);
        }
    }
}