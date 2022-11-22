using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using TodoApi.Data;
//using TwelveDataSharp;
//using TwelveDataSharp.Interfaces;
//using TwelveDataSharp.Library.ResponseModels;
using TodoApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

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

        public class Price
        {
            public string Amount { get; set; }
        }

        //Working with HttpClient
        //public async Task<Price> GetPriceAsync()
        //{
        //    string endPoint = "https://api.twelvedata.com/price?symbol=AAPL&apikey=80576d2956804a20b19f71a0a9f15469&format=JSON";

        //    var response = await this.client.GetAsync(endPoint);
        //    string responseString = await response.Content.ReadAsStringAsync();
        //    var jsonResponse = JsonConvert.DeserializeObject<TwelveDataPrice>(responseString);
        //    Price price = new Price
        //    {
        //        Amount = jsonResponse.Price,
        //    };
        //    return price;
        //}

        //Working with IHttpClientFactory
        public async Task<TwelveDataResult> GetPriceAsync()
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

        //Not working
        //public async Task<Price> GetPrice()
        //{
        //    Price price = new Price();
        //    string apiUrl = "https://api.twelvedata.com/price?symbol=AAPL&apikey=80576d2956804a20b19f71a0a9f15469&format=JSON";
        //    HttpResponseMessage response = this.client.GetAsync(apiUrl).Result;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        price = JsonConvert.DeserializeObject<Price>(response.Content.ReadAsStringAsync().Result);
        //    }
        //    Console.WriteLine(price);
        //    return price;
        //}

        //Not Working
        //public async Task<Price> GetMyObjectAsync(CancellationToken cts = default)
        //{
        //    // http get request to a rest api address
        //    var myObject = await this.client.GetFromJsonAsync<Price>("https://api.twelvedata.com/price?symbol=AAPL&apikey=80576d2956804a20b19f71a0a9f15469&format=JSON", cts);

        //    // raise error if deserialization was not possible
        //    if (myObject == null)
        //        throw new Exception("Oops... Something went wrong");

        //    return myObject;
        //}

        //public async Task<Price> OnGet()
        //{
        //    //Refactoring from both and its working on the console with ReadAsStringAsync()
        //    var request = new HttpRequestMessage(HttpMethod.Get, "price?symbol=AAPL&apikey=80576d2956804a20b19f71a0a9f15469&format=JSON");
        //    var client = this.clientFactory.CreateClient("twelveData");
        //    using (var response = await client.SendAsync(request))
        //    {
        //        response.EnsureSuccessStatusCode();
        //        var body = await response.Content.ReadAsStreamAsync();
        //        //Not working
        //        Price price = await JsonSerializer.DeserializeAsync<Price>(body);
        //        Console.WriteLine(body);
        //        return price;
        //    }

        //    //var request = new HttpRequestMessage(HttpMethod.Get, "price?symbol=AAPL&apikey=80576d2956804a20b19f71a0a9f15469");

        //    //var client = this.clientFactory.CreateClient("twelveData");
        //    //var response = await client.SendAsync(request);
        //    //if (response.IsSuccessStatusCode)
        //    //{
        //    //    using var responseStream = await response.Content.ReadAsStreamAsync();
        //    //    Console.WriteLine(responseStream);
        //    //    //TwelveDataPrice responseObject = await JsonSerializer.DeserializeAsync<TwelveDataPrice>(responseStream);
        //    //    //var result = new TwelveDataPrice
        //    //    //{
        //    //    //    Price = responseObject.Price

        //    //    //};
        //    //    //Console.WriteLine($"Price: {result.Price}");
        //    //}
        //    //else
        //    //{
        //    //    NoContent();
        //    //}
        //}

        //returns price=0
        //[HttpGet]
        //public async Task<TwelveDataPrice> GetPrice()
        //{
        //    var response = await this.client.GetAsync($"https://api.twelvedata.com/price?symbol=AAPL&apikey=80576d2956804a20b19f71a0a9f15469");

        //    using var responseStream = await response.Content.ReadAsStreamAsync();
        //    var responseObject = await JsonSerializer.DeserializeAsync<TwelveDataResult>(responseStream);
        //    return new TwelveDataPrice
        //    {
        //        Price = responseObject.Price
        //    };
        //}

        //[HttpGet]
        //public async Task<ActionResult> GetPrice()
        //{
        //    var client = new HttpClient();
        //    var request = new HttpRequestMessage
        //    {
        //        Method = HttpMethod.Get,
        //        RequestUri = new Uri("https://api.twelvedata.com/time_series?apikey=80576d2956804a20b19f71a0a9f15469&interval=1min"),
        //    };
        //    using (var response = await client.SendAsync(request))
        //    {
        //        response.EnsureSuccessStatusCode();
        //        var body = await response.Content.ReadAsStringAsync();
        //        Console.WriteLine(body);
        //    }
        //}

        //[HttpGet]
        //[Route("GetPrice/{symbol}")]
        //public async Task<ActionResult> GetPrice(string symbol)
        //{
        //    var response = await this.twelveDataService.GetRealTimePriceAsync(symbol);
        //    return Ok(response?.Price);
        //}      
    }
}
