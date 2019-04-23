using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetCoreWebAPI.DbContexts;
using DotNetCoreWebAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreWebAPI.Repository
{
    public class BookRepository : IBookRepository<Book>
    {
        private readonly BookContext _dbContext;

        public BookRepository(BookContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _dbContext.Books.ToListAsync();
        }


        public async Task<Book> Get(long id)
        {
            return await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == id);
        }


        public async Task Add(Book entity)
        {
            await _dbContext.Books.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Book book, Book entity)
        {
            book.Name = entity.Name;
            book.Author = entity.Author;
            book.ISBN = entity.ISBN;
            book.Published = entity.Published;

            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Book book)
        {
            _dbContext.Remove(book);
            await _dbContext.SaveChangesAsync();
        }
    }
}
