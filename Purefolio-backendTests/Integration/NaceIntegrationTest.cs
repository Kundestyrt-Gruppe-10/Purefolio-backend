using Newtonsoft.Json;
using Purefolio_backend;
using Purefolio_backend.Models;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using System.Linq;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using System;

namespace Purefolio_backendTests.IntegrationTests
{
    public class NaceIntegrationTest : IClassFixture<CustomWebApplicationFactory<Startup>>
  {
        private readonly HttpClient _client;
        private readonly ILogger<NaceIntegrationTest> _logger;

        public NaceIntegrationTest(
            CustomWebApplicationFactory<Startup> factory
        
            )
        {
            _client = factory.CreateClient();
            //_logger = logger;
        }

        //[Theory]
        //[InlineData("/naces")]
        [Fact]
        public async Task CanGetNaces()
        {
            // The endpoint or route of the controller action.
            var httpResponse = await _client.GetAsync("/naces");
            //_logger.LogError(httpResponse.Content.ToString());

            // Must be successful.
            httpResponse.EnsureSuccessStatusCode();

            // Deserialize and examine results.
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var naces= JsonConvert.DeserializeObject<IEnumerable<Nace>>(stringResponse);
            var mockData = new MockData();
            // TODO: Should probably check more that the first object
            Assert.Equal(naces.First(), mockData.getAllNaces().First<Nace>());
        }


        [Fact]
        public async Task CanGetNaceById()
        {
            // TODO: Implement
            /*
            // The endpoint or route of the controller action.
            var httpResponse = await _client.GetAsync("/naces/1");

            // Must be successful.
            httpResponse.EnsureSuccessStatusCode();

            // Deserialize and examine results.
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var player = JsonConvert.DeserializeObject<Nace>(stringResponse);
            //Assert.Equal(1, player.Id);
            //Assert.Equal("Wayne", player.FirstName);
            */
        }
    }
}
