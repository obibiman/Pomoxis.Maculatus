using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ArticleCommands.WebAPI.Tests
{
    public class CustomerControllerTests : IDisposable
    {
        protected TestServer _testServer;

        public CustomerControllerTests()
        {
            var webBuilder = new WebHostBuilder();
            webBuilder.UseStartup<Startup>();
            _testServer = new TestServer(webBuilder);
        }

        public void Dispose()
        {
            _testServer.Dispose();
        }

        [Fact]
        public async Task GetAllCustomers_Test()
        {
            var response = await _testServer.CreateRequest("/api/GetAllCustomers").SendAsync("GET");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task GetCustomerById_Test()
        {
            var response = await _testServer.CreateRequest("/api/GetCustomerById/2").SendAsync("GET");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task CreateCustomer_Test()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/CreateCustomer");

            request.Content = new StringContent(JsonConvert.SerializeObject(new Dictionary<string, string>
            {
                {
                    "FirstName", "Dianne"
                }
        }), Encoding.Default, "application/json");

            var client = _testServer.CreateClient();
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.SendAsync(request);

            response = await _testServer.CreateRequest("/api/GetCustomerById/1").SendAsync("GET");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}