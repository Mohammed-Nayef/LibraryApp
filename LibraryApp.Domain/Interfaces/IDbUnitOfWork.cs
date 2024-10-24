using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Domain.Interfaces
{
    public interface IDbUnitOfWork : IDisposable
    {
        int Save();
    }
}
