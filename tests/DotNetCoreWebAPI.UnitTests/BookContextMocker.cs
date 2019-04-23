using DotNetCoreWebAPI.DbContexts;
using DotNetCoreWebAPI.Model;
using DotNetCoreWebAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreWebAPI.UnitTests
{
    public static class BookContextMocker
    {
        public static IBookRepository<Book> GetInMemoryBooksRepository(string dbName)
        {
            var options = new DbContextOptionsBuilder<BookContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            BookContext bookContext = new BookContext(options);
            BookContext.FillDatabase();

            return new BookRepository(bookContext);
        }
    }
}
