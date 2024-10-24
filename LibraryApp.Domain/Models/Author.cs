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
    public class Author : IUserDerivedEntity
    {
        public int Id { get; set; }
        
        public int AppUserId { get; set; }
        public virtual AppUser? AppUser { get; set; }

    }
}
