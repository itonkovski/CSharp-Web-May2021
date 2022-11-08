using System;
namespace TestWebApi.Models
{
    public class Currency
    {
        //    "datetime": "2022-09-23T00:00:00",
        //"open": 1.0165,
        //"high": 1.02385,
        //"low": 1.015,
        //"close": 1.0231,
        //"volume": 0
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Open { get; set; }
        public string Low { get; set; }
        public string Close { get; set; }
    }
}
