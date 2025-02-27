using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace publisherproject.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; } = null!;
        public DateOnly PublishDate { get; set; }

        //[Precision(7,2)]
        public decimal BasePrice { get; set; }

        //[Range(1,13,ErrorMessage ="mellem 1 til 13")]
        //public int Rating { get; set; }
        public Author? Author { get; set; }
        public int AuthorId { get; set; }
        //public Cover Cover { get; set; }
    }
}
