using LibraryApp.Domain.Models;

namespace LibraryApp.API.DTOs.Requests
{
    public class PostBookBorrowRequest
    {
        public int CustomerId { get; set; }
        public int BookId { get; set; }
    }
}
