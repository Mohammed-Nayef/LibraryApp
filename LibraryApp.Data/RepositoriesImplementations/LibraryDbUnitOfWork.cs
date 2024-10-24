using LibraryApp.Domain.Interfaces;
using LibraryApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Data.RepositoriesImplementations
{
    public class LibraryDbUnitOfWork : ILibraryDbUnitOfWork
    {
        private readonly LibraryAppDbContext dbContext;

        public IRepository<AppUser> AppUsers { get; set; }
        public IUserDerivedEntityRepository<Author> Authors { get; set; }
        public IUserDerivedEntityRepository<Customer> Customers { get; set; }
        public IUserDerivedEntityRepository<Employee> Employees { get; set; }
        public IRepository<Subcategory> Subcategories { get; set; }
        public IRepository<Book> Books { get; set; }
        public IRepository<BookBorrow> BookBorrows { get; set; }
        public IRepository<Category> Categories { get; set; }

        public LibraryDbUnitOfWork(LibraryAppDbContext dbContext)
        {
            this.dbContext = dbContext;


        }
        public void Dispose()
        {
            dbContext.Dispose();
        }

        public int Save()
        {
           return dbContext.SaveChanges();
        }
    }
}
