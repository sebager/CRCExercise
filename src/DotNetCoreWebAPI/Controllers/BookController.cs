using System.Threading.Tasks;
using DotNetCoreWebAPI.Model;
using DotNetCoreWebAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreWebAPI.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBookRepository<Book> _bookRepository;

        public BookController(IBookRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _bookRepository.GetAll();

            if (books == null)
            {
                return NotFound("Books couldn't be found.");
            }

            return Ok(books);
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(long id)
        {
            var book = await _bookRepository.Get(id);

            if (book == null)
            {
                return NotFound("The book couldn't be found.");
            }

            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Book book)
        {
            if (book == null)
            {
                return BadRequest("Book is null.");
            }

            await _bookRepository.Add(book);

            return CreatedAtAction(nameof(Get), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, Book book)
        {
            var bookToUpdate = await _bookRepository.Get(id);

            if (bookToUpdate == null)
            {
                return NotFound("The book couldn't be found.");
            }

            await _bookRepository.Update(bookToUpdate, book);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var bookToDelete = await _bookRepository.Get(id);

            if (bookToDelete == null)
            {
                return NotFound("The book couldn't be found.");
            }

            await _bookRepository.Delete(bookToDelete);

            return NoContent();
        }
    }
}