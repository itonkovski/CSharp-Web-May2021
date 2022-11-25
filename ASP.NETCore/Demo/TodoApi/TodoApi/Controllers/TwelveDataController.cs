using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Data;
using TodoApi.Data.Models.RealTimePrice;
using System;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;

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



        //Working with IHttpClientFactory
        //SaveChanges to the dBContext
        //[HttpPost]
        public async Task<TwelveDataPrice> GetRealTimePriceAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"price?symbol=AAPL&apikey={this.configuration["TwelveData:ApiKey"]}&format=JSON");
            var client = this.clientFactory.CreateClient("twelveData");
            //Guid guid = Guid.NewGuid();
            //string str = guid.ToString();
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var jsonResponse = JsonConvert.DeserializeObject<TwelveDataPriceResult>(body);
                TwelveDataPrice result = new TwelveDataPrice
                {
                    Id = GenerateGuid(),
                    Price = jsonResponse.Price
                };
                this.dbContext.TwelveDataPrices.Add(result);
                await this.dbContext.SaveChangesAsync();
                return result;

            }
        }

        private string GenerateGuid()
        {
            Guid guid = Guid.NewGuid();
            string str = guid.ToString();
            return str;
        }

        //[HttpGet]
        //public async Task GetForexPairsAsync()
        //{
        //    var request = new HttpRequestMessage(HttpMethod.Get, $"forex_pairs");
        //    var client = this.clientFactory.CreateClient("twelveData");
        //    using (var response = await client.SendAsync(request))
        //    {
        //        response.EnsureSuccessStatusCode();
        //        var body = await response.Content.ReadAsStringAsync();
        //        var jsonResponse = JsonConvert.DeserializeObject<TwelveDataForexPairResult>(body);
        //        List<Pair> pairs = new List<Pair>();
        //        var tsPairs = jsonResponse?.Pairs;
        //        pairs.AddRange(tsPairs.Select(p => new Pair()
        //        {
        //            Symbol = p.Symbol,
        //            CurrencyGroup = p.CurrencyGroup,
        //            CurrencyBase = p.CurrencyBase,
        //            CurrencyQuote = p.CurrencyQuote
        //        }));
        //        Console.WriteLine(pairs);
        //    }
        //}
    }
}
