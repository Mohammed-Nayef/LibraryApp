using LibraryApp.Domain.Common.Interfaces;
using LibraryApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Domain.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        Book? GetWithTFullNavigations(int id);
        List<Book> GetByCategoryName(string categoryName);
        List<Book> GetByCategoryId(int id);
        List<Book> GetAllByPage(IPaginationOptions paginationOptions);
        List<Book> GetByCategoryAndSubcategory(int categoryId,int subcategoryId);

    }
}
