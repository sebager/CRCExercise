using DotNetCoreWebAPI.DbContexts;
using DotNetCoreWebAPI.Model;
using System;

namespace DotNetCoreWebAPI.UnitTests
{
    public static class BookContextExtensions
    {
        public static void FillDatabase(this BookContext dbContext)
        {
            dbContext.Books.Add
            (
                new Book
                {
                    Id = 1,
                    Name = "Book_01",
                    Author = "Author_01",
                    ISBN = "1234567891478",
                    Published = Convert.ToDateTime("2019/04/20")
                }
            );

            dbContext.Books.Add
            (
                new Book
                {
                    Id = 2,
                    Name = "Book_02",
                    Author = "Author_02",
                    ISBN = "1234162893278",
                    Published = Convert.ToDateTime("2019/03/20")
                }
            );

            dbContext.Books.Add
            (
                new Book
                {
                    Id = 3,
                    Name = "Book_03",
                    Author = "Author_03",
                    ISBN = "3334167491378",
                    Published = Convert.ToDateTime("2019/02/14")
                }
            );

            dbContext.Books.Add
            (
                new Book
                {
                    Id = 4,
                    Name = "Book_04",
                    Author = "Author_04",
                    ISBN = "1434467491478",
                    Published = Convert.ToDateTime("2019/04/20")
                }
            );

            dbContext.Books.Add
            (
                new Book
                {
                    Id = 5,
                    Name = "Book_05",
                    Author = "Author_05",
                    ISBN = "1554567591578",
                    Published = Convert.ToDateTime("2019/04/20")
                }
            );


            dbContext.SaveChanges();
        }
    }
}
