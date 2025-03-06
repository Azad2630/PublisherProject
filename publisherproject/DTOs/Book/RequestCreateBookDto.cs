using System.ComponentModel.DataAnnotations;

namespace publisherproject.DTOs.Book
{
    public class RequestCreateBookDto
    {
        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public DateOnly PublishDate { get; set; }

        [Required]
        public decimal BasePrice { get; set; }

        [Required]
        [Range(1, 13, ErrorMessage = "Rating skal være mellem 1 og 13.")]
        public int Rating { get; set; }

        public int? AuthorId { get; set; }
    }
}
