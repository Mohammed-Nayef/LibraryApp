using System.ComponentModel.DataAnnotations;

namespace LibraryApp.API.DTOs.Requests
{
    public class PutBookRequest
    {
        public required string Title { get; set; }
        public required string Description { get; set; }


        public int AuthorId { get; set; }


        public int CategoryId { get; set; }


        public int SubcategoryId { get; set; }


        [Required]
        public DateOnly PublishedDate { get; set; }
    }
}
