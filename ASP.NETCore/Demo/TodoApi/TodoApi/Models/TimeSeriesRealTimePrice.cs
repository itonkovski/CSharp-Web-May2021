using System;
using Newtonsoft.Json;

namespace TodoApi.Models
{
    public class TimeSeriesRealTimePrice
    {
        [JsonProperty("price")]
        public string Price { get; set; }
    }
}
