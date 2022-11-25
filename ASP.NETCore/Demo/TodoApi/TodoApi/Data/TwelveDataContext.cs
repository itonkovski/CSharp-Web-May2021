using System;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data.Models.ForexPair;
using TodoApi.Data.Models.RealTimePrice;

namespace TodoApi.Data
{
    public class TwelveDataContext : DbContext
    {
        public TwelveDataContext(DbContextOptions<TwelveDataContext> options)
            :base(options)
        {

        }

        public DbSet<TwelveDataPrice> TwelveDataPrices { get; set; }
        public DbSet<TwelveDataForexPair> TwelveDataForexPairs { get; set; }
    }
}
