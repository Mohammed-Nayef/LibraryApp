using LibraryApp.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace LibraryApp.API.DTOs.Requests
{
    public class PostBookRequest
    {

        public required string Title { get; set; }
        public required string Description { get; set; }


        public int AuthorId { get; set; }


        public int CategoryId { get; set; }


        public int SubcategoryId { get; set; }

        //public virtual List<BookTag> BookTags { get; set; } = [];
        public List<int> TagsIds { get; set; } = [];
        [Required]
        public DateOnly PublishedDate { get; set; } 

    }
}
