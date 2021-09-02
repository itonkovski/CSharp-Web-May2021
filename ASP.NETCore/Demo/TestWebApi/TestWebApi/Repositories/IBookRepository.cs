using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestWebApi.Models;

namespace TestWebApi.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> Get();
        Task<Book> Get(int id);
        Task<Book> Create(Book  book);
        Task Update(Book  book);
        Task Delete(int id);
    }
}
