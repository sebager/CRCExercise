using DotNetCoreWebAPI.Controllers;
using DotNetCoreWebAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace DotNetCoreWebAPI.UnitTests.Controllers
{
    public class BookControllerUnitTests
    {
        [Fact]
        public async Task get_all_books()
        {
            // Arrange 
            var repository = BookContextMocker.GetInMemoryBooksRepository(nameof(get_all_books));
            var controller = new BookController(repository);

            // Act
            var response = await controller.GetAll() as ObjectResult;
            var books = response.Value as List<Book>;

            // Assert
            Assert.Equal(200, response.StatusCode);
            Assert.Equal(5, books.Count);
        }

        [Fact]
        public async Task get_book_with_existing_id()
        {
            // Arrange 
            var repository = BookContextMocker.GetInMemoryBooksRepository(nameof(get_book_with_existing_id));
            var controller = new BookController(repository);
            var expectedValue = "1234567891478";

            // Act
            var response = await controller.Get(1) as ObjectResult;
            var book = response.Value as Book;

            // Assert
            Assert.Equal(200, response.StatusCode);
            Assert.Equal(expectedValue, book.ISBN);
        }

        [Fact]
        public async Task get_book_with_not_existing_id()
        {
            // Arrange 
            var repository = BookContextMocker.GetInMemoryBooksRepository(nameof(get_book_with_not_existing_id));
            var controller = new BookController(repository);
            var expectedMessage = "The book couldn't be found.";

            // Act
            var response = await controller.Get(50) as ObjectResult;

            // Assert
            Assert.Equal(404, response.StatusCode);
            Assert.Equal(expectedMessage, response.Value);
        }

        [Fact]
        public async Task post_null_book()
        {
            // Arrange 
            var repository = BookContextMocker.GetInMemoryBooksRepository(nameof(post_null_book));
            var controller = new BookController(repository);
            var expectedMessage = "Book is null.";

            // Act
            var response = await controller.Post(null) as ObjectResult;

            // Assert
            Assert.Equal(400, response.StatusCode);
            Assert.Equal(expectedMessage, response.Value);
        }

        [Fact]
        public async Task post_correct_book()
        {
            // Arrange 
            var repository = BookContextMocker.GetInMemoryBooksRepository(nameof(post_correct_book));
            var controller = new BookController(repository);
            var book = new Book
            {
                Id = 7,
                Name = "Book_07",
                Author = "Author_07",
                ISBN = "1478547889874",
                Published = Convert.ToDateTime("2017/10/12")
            };

            // Act
            var response = await controller.Post(book) as ObjectResult;
            var addedBook = response.Value as Book;

            // Assert
            Assert.Equal(201, response.StatusCode);
            Assert.Equal(7, addedBook.Id);
        }

        [Fact]
        public async Task delete_book_with_existing_id()
        {
            // Arrange 
            var repository = BookContextMocker.GetInMemoryBooksRepository(nameof(delete_book_with_existing_id));
            var controller = new BookController(repository);
            var expectedMessage = "The book couldn't be found.";


            // Act
            await controller.Delete(1);
            var book = await controller.Get(1) as ObjectResult;

            // Assert
            Assert.Equal(expectedMessage, book.Value);
        }

        [Fact]
        public async Task delete_book_with_not_existing_id()
        {
            // Arrange 
            var repository = BookContextMocker.GetInMemoryBooksRepository(nameof(delete_book_with_not_existing_id));
            var controller = new BookController(repository);
            var expectedMessage = "The book couldn't be found.";


            // Act
            var response = await controller.Delete(60) as ObjectResult;

            // Assert
            Assert.Equal(404, response.StatusCode);
            Assert.Equal(expectedMessage, response.Value);
        }

        [Fact]
        public async Task update_book_with_existing_id()
        {
            // Arrange 
            var repository = BookContextMocker.GetInMemoryBooksRepository(nameof(update_book_with_existing_id));
            var controller = new BookController(repository);
            var book = new Book
            {
                Id = 7,
                Name = "Book_07",
                Author = "Author_07",
                ISBN = "1478547889874",
                Published = Convert.ToDateTime("2017/10/12")
            };

            // Act
            var response = await controller.Put(3, book) as ObjectResult;
            var get = await controller.Get(3) as ObjectResult;
            var changedBook = get.Value as Book;

            // Assert
            Assert.Equal(200, get.StatusCode);
            Assert.Equal("Book_07", changedBook.Name);
            Assert.Equal("Author_07", changedBook.Author);
            Assert.Equal("1478547889874", changedBook.ISBN);
            Assert.Equal(Convert.ToDateTime("2017/10/12"), Convert.ToDateTime(changedBook.Published));
        }

        [Fact]
        public async Task update_book_with_not_existing_id()
        {
            // Arrange 
            var repository = BookContextMocker.GetInMemoryBooksRepository(nameof(update_book_with_not_existing_id));
            var controller = new BookController(repository);
            var expectedMessage = "The book couldn't be found.";
            var book = new Book
            {
                Id = 7,
                Name = "Book_07",
                Author = "Author_07",
                ISBN = "1478547889874",
                Published = Convert.ToDateTime("2017/10/12")
            };

            // Act
            var response = await controller.Put(10, book) as ObjectResult;

            // Assert
            Assert.Equal(404, response.StatusCode);
            Assert.Equal(expectedMessage, response.Value);
        }
    }
}
