using System;
using System.Threading.Tasks;
using TestWebApi.Models;

namespace TestWebApi.Repositories
{
    public interface ICurrencyRepository
    {
        Task<Currency> Create(Currency currency);
    }
}
