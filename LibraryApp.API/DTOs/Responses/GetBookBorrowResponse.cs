using LibraryApp.Domain.Models;

namespace LibraryApp.API.DTOs.Responses
{
    public class GetBookBorrowResponse
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int BookId { get; set; }

        // nullable used in CustomerController.GetBookBorrow(int id,int bookBorrowId) 
        public GetBookResponse? Book { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
