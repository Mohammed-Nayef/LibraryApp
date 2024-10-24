using LibraryApp.Data;
using LibraryApp.Data.RepositoriesImplementations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Domain.Interfaces
{
    public class UserDerivedEntityRepository<T> : Repository<T>, IUserDerivedEntityRepository<T> where T : class, IUserDerivedEntity
    {
        public UserDerivedEntityRepository(LibraryAppDbContext context) : base(context)
        {
        }
        public List<T> GetAllWithUserInfo()
        {
            return this._dbContext.Set<T>()
                .Include(ud => ud.AppUser)
                .Where(u => !u.AppUser!.IsDeleted)
            .ToList();
        }

        public T? GetWithUserInfo(int id)
        {
            return _dbContext.Set<T>()
                .Include(ud => ud.AppUser)
                .Where(ud => ud.Id == id && !ud.AppUser!.IsDeleted)
                .FirstOrDefault(); ;
        }
    }
}
