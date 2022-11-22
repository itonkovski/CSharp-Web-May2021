using System;
using System.Threading.Tasks;
using TodoApi.Data.Models;

namespace TodoApi.Services
{
    public interface ITwelveDataService
    {
        Task<TwelveDataPrice> GetRealTimePriceAsync(string symbol);
    }
}
