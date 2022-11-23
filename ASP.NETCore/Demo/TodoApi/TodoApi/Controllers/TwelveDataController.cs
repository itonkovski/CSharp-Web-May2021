using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Data;
using TodoApi.Data.Models;
using System;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TwelveDataController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IHttpClientFactory clientFactory;
        private readonly TwelveDataContext dbContext;
        private readonly HttpClient client;

        public TwelveDataController(IConfiguration configuration, IHttpClientFactory clientFactory, TwelveDataContext dbContext, HttpClient client)
        {
            this.configuration = configuration;
            this.clientFactory = clientFactory;
            this.dbContext = dbContext;
            this.client = client;
        }

        //public async Task<TwelveDataResult> Index()
        //{
        //    var result = await GetRealTimeResult();
        //    return result;
        //}

        //private async Task<TwelveDataResult> GetRealTimeResult()
        //{
        //    var result = await this.twelveDataService.GetRealTimePriceAsync("AAPL");

        //    return result;
        //}

        //Working with IHttpClientFactory
        public async Task<TwelveDataResult> GetRealTimePriceAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"price?symbol=AAPL&apikey={this.configuration["TwelveData:ApiKey"]}&format=JSON");
            var client = this.clientFactory.CreateClient("twelveData");
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var jsonResponse = JsonConvert.DeserializeObject<TwelveDataPrice>(body);
                TwelveDataResult result = new TwelveDataResult
                {
                    Amount = jsonResponse.Price
                };
                return result;
            }
        }
    }
}
