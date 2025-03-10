﻿using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace publisherproject.DTOs.Book
{
    public class BookDto
    {
        public int BookId { get; set; }
        public string Title { get; set; } = null!;
        public DateOnly PublishDate { get; set; }
        public decimal BasePrice { get; set; }

        [Range(1, 13, ErrorMessage = "Price must be between 1 and 13.")]
        public int Rating { get; set; }
        [JsonIgnore]
        public publisherproject.Models.Author Author { get; set; } = new();
        public int AuthorId { get; set; }
    }
}
