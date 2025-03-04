using System.ComponentModel.DataAnnotations;

namespace publisherproject.DTOs.Author
{
    public class RequestCreateAuthorDto
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
    }
}