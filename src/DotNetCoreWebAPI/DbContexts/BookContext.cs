using DotNetCoreWebAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreWebAPI.DbContexts
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}
