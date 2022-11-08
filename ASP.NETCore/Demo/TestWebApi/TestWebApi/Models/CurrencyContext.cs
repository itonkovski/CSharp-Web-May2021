using System;
using Microsoft.EntityFrameworkCore;

namespace TestWebApi.Models
{
    public class CurrencyContext : DbContext
    {
        public CurrencyContext(DbContextOptions<CurrencyContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Currency> Currencies { get; set; }
    }
}
