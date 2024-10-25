using LibraryApp.Domain.Models;

namespace LibraryApp.API.DTOs.Responses
{
    public class GetBookResponse
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }

        public required string CategoryName { get; set; }
        public required string SubcategoryName { get; set; }
        public required List<string> Tags { get; set; }
        public int AuthorId { get; set; }
        // TODO : Add GetAuthorResponse 
        //public virtual Author? Author { get; set; }

        public int CategoryId { get; set; }
        

        public int SubcategoryId { get; set; }

        public DateOnly PublishedDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
