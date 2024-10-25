using LibraryApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Domain.Interfaces
{
    public interface ICustomerRepository : IUserDerivedEntityRepository<Customer>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns> a list of BookBorrow with the Book object included</returns>
        List<BookBorrow> GetCustomerBookBorrows(int id);
    }
}
