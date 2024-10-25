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
    public class CustomerRepository : UserDerivedEntityRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(LibraryAppDbContext context) : base(context)
        {
        }

        public List<BookBorrow> GetCustomerBookBorrows(int id)
        {
            return _dbContext.Set<BookBorrow>()
                .Where(x=> x.CustomerId == id)
                .Include(x => x.Book)
                .ToList();
        }
    }
}
