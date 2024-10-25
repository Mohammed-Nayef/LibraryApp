using LibraryApp.Domain.Interfaces;
using LibraryApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Data.RepositoriesImplementations
{
    public class AppUserRepository : Repository<AppUser>, IAppUserRepository
    {
        public AppUserRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public AppUser? GetByEmail(string email)
        {
            return this._dbContext.Set<AppUser>()
                .Where(appUser => appUser.Email == email)
                .Where(appUser => !appUser.IsDeleted)
                .FirstOrDefault();
        }

        public bool IsEmailUsed(string email)
        {
            return _dbContext.Set<AppUser>()
                 .Any(appUser => appUser.Email == email);
        }
    }
}
