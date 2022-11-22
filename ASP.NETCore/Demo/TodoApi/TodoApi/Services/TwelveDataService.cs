//using System;
//using System.Net.Http;
//using System.Threading.Tasks;
//using Newtonsoft.Json;
//using TodoApi.Data.Models;
//using TodoApi.Models;

//namespace TodoApi.Services
//{
//    public class TwelveDataService : ITwelveDataService
//    {
//        private readonly string apiKey;
//        private readonly HttpClient client;

//        public TwelveDataService(string key, HttpClient client)
//        {
//            this.apiKey = key;
//            this.client = client;
//        }

//        /*
//         * Asynchronously get a real time price for a particular NASDAQ or NYSE listed equity or ETF with a specified interval
//         * symbol - a valid symbol for an equity or ETF listed on the NASDAQ or NYSE
//         */
//        public async Task<TwelveDataPrice> GetRealTimePriceAsync(string symbol)
//        {
//            try
//            {
//                string endpoint = "https://api.twelvedata.com/price?symbol=" + symbol + "&apikey=" + apiKey;
//                var response = await client.GetAsync(endpoint);
//                string responseString = await response.Content.ReadAsStringAsync();
//                var jsonResponse = JsonConvert.DeserializeObject<TimeSeriesRealTimePrice>(responseString);
//                TwelveDataPrice realTimePrice = new TwelveDataPrice()
//                {
//                    Price = Convert.ToDouble(jsonResponse?.Price)
//                };

//                if (!realTimePrice.Price.Equals(0)) return realTimePrice;
//                //realTimePrice.ResponseStatus = Enums.TwelveDataClientResponseStatus.TwelveDataApiError;
//                //realTimePrice.ResponseMessage = "Invalid symbol or bad API key";

//                return realTimePrice;
//            }
//            catch (Exception e)
//            {
//                return new TwelveDataPrice()
//                {
//                    //ResponseStatus = Enums.TwelveDataClientResponseStatus.TwelveDataSharpError,
//                    //ResponseMessage = e.ToString()
//                };
//            }
//        }
//    }
//}
