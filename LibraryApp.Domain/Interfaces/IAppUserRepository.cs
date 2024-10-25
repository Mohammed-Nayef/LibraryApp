using LibraryApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Domain.Interfaces
{
    public interface IAppUserRepository : IRepository<AppUser>
    {
        AppUser? GetByEmail(string email);
        bool IsEmailUsed(string email);
    }
}
