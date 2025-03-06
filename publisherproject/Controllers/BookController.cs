using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using publisherproject.Data;
using publisherproject.DTOs.Book; 
using publisherproject.Interfaces;
using publisherproject.Mappers;   
using publisherproject.Models;

namespace publisherproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        //private readonly PublisherContext _context;
        private readonly IBookRepository _bookRepository;

        //public BookController(PublisherContext context, IBookRepository bookRepository)
        //{
        //    _context = context;
        //    _bookRepository = bookRepository;
        //}
        public BookController(IBookRepository bookRepository)
        {
            this._bookRepository = bookRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var books = await _bookRepository.GetAllAsync();
            var bookDtos = books.Select(b => b.FromBookToBookDto());
            return Ok(bookDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            BookDto bookDto = book.FromBookToBookDto();
            return Ok(bookDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RequestCreateBookDto createBookDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var book = createBookDto.ToBook(); 
            await _bookRepository.CreateAsync(book);

            return Ok(book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateBookRequestDto updateBookDto)
        {
            if (id != updateBookDto.BookId)
            {
                return BadRequest("BookId mismatch");
            }

            var updatedBook = await _bookRepository.UpdateAsync(id, updateBookDto);
            if (updatedBook == null)
            {
                return BadRequest("Book not updated");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var deletedBook = await _bookRepository.DeleteAsync(id);
            if (deletedBook == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
