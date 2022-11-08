using System;
using System.Threading.Tasks;
using TestWebApi.Models;

namespace TestWebApi.Repositories
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly CurrencyContext currencyContext;

        public CurrencyRepository(CurrencyContext currencyContext)
        {
            this.currencyContext = currencyContext;
        }

        public async Task<Currency> Create(Currency currency)
        {
            this.currencyContext.Currencies.Add(currency);
            await this.currencyContext.SaveChangesAsync();

            return currency;
        }
    }
}
