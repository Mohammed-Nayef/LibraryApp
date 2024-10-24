using LibraryApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Domain.Interfaces
{
    public interface ILibraryDbUnitOfWork : IDbUnitOfWork
    {
        IAppUserRepository AppUsers { get; set; }
        IUserDerivedEntityRepository<Author> Authors { get; set; }
        IUserDerivedEntityRepository<Customer> Customers { get; set; }
        IUserDerivedEntityRepository<Employee> Employees { get; set; }
        IRepository<Subcategory> Subcategories { get; set; }
        IRepository<Book> Books { get; set; }
        IRepository<BookBorrow> BookBorrows { get; set; }
        IRepository<Category> Categories { get; set; }
        IRepository<Tag> Tags { get; set; }
        IRepository<BookTag> BookTags { get; set; }

    }
}
