using LibraryApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Domain.Interfaces
{
    public interface IUserDerivedEntity
    {
         int Id { get; set; }
         int AppUserId { get; set; }
         AppUser? AppUser { get; set; }
    }
}
