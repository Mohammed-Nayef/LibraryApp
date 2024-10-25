using System.ComponentModel.DataAnnotations;

namespace LibraryApp.API.DTOs.Responses
{
    public class GetCustomerResponse
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        [MaxLength(50)]
        public required string FirstName { get; set; }
        [MaxLength(50)]
        public required string LastName { get; set; }
        [MaxLength(100)]
        [EmailAddress]
        public required string Email { get; set; }

        [MaxLength(50)]
        [Phone]
        public required string PhoneNumber { get; set; }

        [Required]
        public DateOnly Birthdate { get; set; }

    }
}
