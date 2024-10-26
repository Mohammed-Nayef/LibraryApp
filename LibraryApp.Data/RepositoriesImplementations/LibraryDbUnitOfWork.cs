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

        public IAppUserRepository AppUsers { get; set; }
        public IUserDerivedEntityRepository<Author> Authors { get; set; }
        public ICustomerRepository Customers { get; set; }
        public IUserDerivedEntityRepository<Employee> Employees { get; set; }
        public IRepository<Subcategory> Subcategories { get; set; }
        public IBookRepository Books { get; set; }
        public IRepository<BookBorrow> BookBorrows { get; set; }
        public ICategoryRepository Categories { get; set; }
        public IRepository<Tag> Tags{ get; set; }
        public IRepository<BookTag> BookTags { get; set; }
        public IStoredProceduresRepository StoredProcedures { get; set; }

        public LibraryDbUnitOfWork(LibraryAppDbContext dbContext)
        {
            this.dbContext = dbContext;

            Books = new BookRepository(dbContext);
            Authors = new UserDerivedEntityRepository<Author>(dbContext);
            Customers = new CustomerRepository(dbContext);
            Employees = new UserDerivedEntityRepository<Employee>(dbContext);
            AppUsers = new AppUserRepository(dbContext);
            Categories = new CategoryRepository(dbContext);
            Subcategories = new Repository<Subcategory>(dbContext);
            BookBorrows = new Repository<BookBorrow>(dbContext);
            BookTags = new Repository<BookTag>(dbContext);
            Tags = new Repository<Tag>(dbContext);
            StoredProcedures = new StoredProceduresRepository(dbContext);

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
