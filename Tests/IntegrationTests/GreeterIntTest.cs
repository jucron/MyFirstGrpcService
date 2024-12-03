using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;
using System.Net.Http.Json;
using MyFirstGrpcService;
using System.Text.Json;
using Tests.Helpers;

namespace Tests.IntegrationTests
{
    public class GreeterIntTest : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _httpClient;

        public GreeterIntTest(CustomWebApplicationFactory<Program> factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Fact]
        public async Task Get_Endpoint_Returns_Success()
        {
            // given
            var endpoint = "/v1/api/john";

            // when
            var response = await _httpClient.GetAsync(endpoint);

            // then
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            string message = await ResponseHelper.getPropertyFromResponse("message", response);
            Assert.NotNull(message);
            Assert.Equal("Hello John", message);
        }

        /*
        // Example of Post testing
        [Fact]
        public async Task Post_Endpoint_Returns_Created()
        {
            var payload = new { Name = "Test", Value = 42 };
            var response = await _client.PostAsJsonAsync("/api/endpoint", payload);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }
        */
    }
}
