using publisherproject.DTOs.Book;
using publisherproject.Models;

namespace publisherproject.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(int id); 
        Task<Book> CreateAsync(Book bookModel);
        Task<Book?> UpdateAsync(int id, UpdateBookRequestDto bookModel);
        Task<Book?> DeleteAsync(int id);
        Task<bool> Exists(int id);
    }
}
