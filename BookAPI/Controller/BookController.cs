using BookAPI.Model;
using BookAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Book>> Get()
        {
            return await _bookRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBooks(int id)
        {
            return await _bookRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> PostBooks([FromBody] Book book)
        {
            var newBook = await _bookRepository.Create(book);
            return CreatedAtAction(nameof(GetBooks), new { id = newBook.id }, newBook);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var bookToDelete = await _bookRepository.Get(id);

            if (bookToDelete == null)
            {
                await _bookRepository.Delete(bookToDelete.id);
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> PutBooks(int id, [FromBody] Book book)
        {
            if (id != book.id)
            {
                await _bookRepository.Update(book);
                return BadRequest();
            }
            return NoContent();
        }
    }
}