//using System;
//using System.Net.Http;
//using System.Threading.Tasks;
//using Microsoft.Extensions.Configuration;
//using Newtonsoft.Json;
//using TodoApi.Data.Models;
//using TodoApi.Models;

//namespace TodoApi.Services
//{
//    public class TwelveDataService : ITwelveDataService
//    {
//        private readonly IConfiguration configuration;
//        private readonly IHttpClientFactory clientFactory;

//        public TwelveDataService(string key, IConfiguration configuration, IHttpClientFactory clientFactory)
//        {
//            this.configuration = configuration;
//            this.clientFactory = clientFactory;
//        }

//        //Working with IHttpClientFactory
//        public async Task<TwelveDataResult> GetRealTimePriceAsync(string symbol)
//        {
//            var request = new HttpRequestMessage(HttpMethod.Get, $"price?symbol={symbol}&apikey={this.configuration["TwelveData:ApiKey"]}&format=JSON");
//            var client = this.clientFactory.CreateClient("twelveData");
//            using (var response = await client.SendAsync(request))
//            {
//                response.EnsureSuccessStatusCode();
//                var body = await response.Content.ReadAsStringAsync();
//                var jsonResponse = JsonConvert.DeserializeObject<TwelveDataPrice>(body);
//                TwelveDataResult result = new TwelveDataResult
//                {
//                    Amount = jsonResponse.Price
//                };
//                return result;
//            }
//        }

//        //Working with HttpClient
//        //public async Task<TwelveDataResult> GetPriceAsync()
//        //{
//        //    string endPoint = "https://api.twelvedata.com/price?symbol=AAPL&apikey=80576d2956804a20b19f71a0a9f15469&format=JSON";

//        //    var response = await this.client.GetAsync(endPoint);
//        //    string responseString = await response.Content.ReadAsStringAsync();
//        //    var jsonResponse = JsonConvert.DeserializeObject<TwelveDataPrice>(responseString);
//        //    TwelveDataResult result = new TwelveDataResult
//        //    {
//        //        Amount = jsonResponse.Price,
//        //    };
//        //    return price;
//        //}
//    }
//}
