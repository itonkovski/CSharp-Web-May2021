using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestWebApi.Models;

namespace TestWebApi.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookContext bookContext;

        public BookRepository(BookContext bookContext)
        {
            this.bookContext = bookContext;
        }

        public async Task<Book> Create(Book book)
        {
            this.bookContext.Books.Add(book);
            await this.bookContext.SaveChangesAsync();

            return book;
        }

        public async Task Delete(int id)
        {
            var bookToDelete = await this.bookContext.Books.FindAsync(id);
            this.bookContext.Books.Remove(bookToDelete);
            await this.bookContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> Get()
        {
            return await this.bookContext.Books.ToListAsync();
        }

        public async Task<Book> Get(int id)
        {
            return await this.bookContext.Books.FindAsync(id);
        }

        public async Task Update(Book book)
        {
            this.bookContext.Entry(book).State = EntityState.Modified;
            await this.bookContext.SaveChangesAsync();
        }
    }
}
