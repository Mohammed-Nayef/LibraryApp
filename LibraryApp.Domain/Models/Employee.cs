using LibraryApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Domain.Models
{
    public class Employee : IUserDerivedEntity
    {
        public int Id { get; set; }
        public required string Title { get; set; }

        public int AppUserId { get; set; }
        public virtual AppUser? AppUser { get; set; }

    }
}
