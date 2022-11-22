using System;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data.Models;

namespace TodoApi.Data
{
    public class TwelveDataContext : DbContext
    {
        public TwelveDataContext(DbContextOptions<TwelveDataContext> options)
            :base(options)
        {

        }

        public DbSet<TwelveDataPrice> TwelveDataPrice { get; set; }
    }
}
