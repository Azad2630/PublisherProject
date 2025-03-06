using publisherproject.DTOs.Book;
using publisherproject.Models;

namespace publisherproject.Mappers
{
    public static class BookMappers
    {
        public static BookDto FromBookToBookDto(this Book bookModel)
        {
            return new BookDto
            {
                Author = bookModel.Author,
                AuthorId = (int)bookModel.AuthorId,
                BasePrice = bookModel.BasePrice,
                BookId = bookModel.BookId,
                PublishDate = bookModel.PublishDate,
                Rating = bookModel.Rating,
                Title = bookModel.Title,
            };
        }

        public static Book ToBook(this RequestCreateBookDto createBookDto)
        {
            return new Book
            {
                Title = createBookDto.Title,
                PublishDate = createBookDto.PublishDate,
                BasePrice = createBookDto.BasePrice,
                Rating = createBookDto.Rating,
                AuthorId = createBookDto.AuthorId
            };
        }
    }
}

