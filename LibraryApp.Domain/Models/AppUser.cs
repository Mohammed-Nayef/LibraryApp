using LibraryApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Domain.Models
{
    public class AppUser : ISoftDeletable
    {

        public int Id { get; set; }
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

        [MaxLength(20)]
        public required string Role { get; set; }



        public virtual Employee? Employee { get; set; }
        public virtual Author? Author { get; set; }
        public virtual Customer? Customer { get; set; }


        [Required]
        public DateOnly Birthdate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime LastUpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
