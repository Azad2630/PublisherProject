using publisherproject.Interfaces;
using publisherproject.Models;
using publisherproject.Data;
using Microsoft.EntityFrameworkCore;
using publisherproject.DTOs.Book;
using publisherproject.Mappers;

namespace publisherproject.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly PublisherContext _context;

        public BookRepository(PublisherContext context)
        {
            this._context = context;
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            var theBook = await _context.Books.Include(c => c.Author).FirstOrDefaultAsync(x => x.BookId == id);
            return theBook;
        }

        public async Task<Book> CreateAsync(Book bookModel)
        {
            _context.Books.Add(bookModel);
            await _context.SaveChangesAsync();
            return bookModel;
        }

        public async Task<Book?> UpdateAsync(int id, UpdateBookRequestDto bookDto)
        {
            var existingBook = await _context.Books.FindAsync(id);
            if (existingBook == null) return null;

            // Opdater felterne
            existingBook.Title = bookDto.Title;
            existingBook.PublishDate = bookDto.PublishDate;
            existingBook.BasePrice = bookDto.BasePrice;
            existingBook.Rating = bookDto.Rating;
            existingBook.AuthorId = bookDto.AuthorId;
            await _context.SaveChangesAsync();

            return existingBook;
        }

        public async Task<Book?> DeleteAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return null;

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return book;
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Books.AnyAsync(b => b.BookId == id);
        }
    }
}
