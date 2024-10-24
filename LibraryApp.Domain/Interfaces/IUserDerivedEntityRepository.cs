using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Domain.Interfaces
{
    public interface IUserDerivedEntityRepository<T> : IRepository<T> where T : class, IUserDerivedEntity
    {
        List<T> GetAllWithUserInfo();
        T? GetWithUserInfo(int id);
    }
}
