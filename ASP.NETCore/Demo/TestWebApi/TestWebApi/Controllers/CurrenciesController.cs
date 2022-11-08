using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestWebApi.Models;
using TwelveDataSharp;
using TwelveDataSharp.Api.ResponseModels;
using TwelveDataSharp.Library.ResponseModels;
using System.Net.Http;
using TwelveDataSharp.Interfaces;
using TestWebApi.Repositories;


namespace TestWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrenciesController : ControllerBase
    {
        private readonly TwelveDataClient _client;
        private readonly string _apiKey;
        private readonly ICurrencyRepository currencyRepository;

        public CurrenciesController(TwelveDataClient client, string key, ICurrencyRepository currencyRepository)
        {
            _client = client;
            _apiKey = key;
            this.currencyRepository = currencyRepository;
        }

        [HttpGet]
        [Route("price")]
        public async Task<ActionResult> GetPrice(string symbol)
        {
            var response = await _client.GetRealTimePriceAsync(symbol);
            return Ok(response?.Price);
        }

        

        // GET: api/Currencies
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Currencies/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Currencies
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Currencies/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/Currencies/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
