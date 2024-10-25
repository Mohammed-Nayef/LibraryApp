using LibraryApp.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace LibraryApp.API.DTOs.Requests
{
    public class PostCustomerRequest
    {
        [MaxLength(50)]
        public required string FirstName { get; set; }
        [MaxLength(50)]
        public required string LastName { get; set; }
        [MaxLength(100)]
        [EmailAddress]
        public required string Email { get; set; }

        public required string PasswordHash { get; set; }
        [MaxLength(50)]
        [Phone]
        public required string PhoneNumber { get; set; }

        [Required]
        public DateOnly Birthdate { get; set; }
    }
}
