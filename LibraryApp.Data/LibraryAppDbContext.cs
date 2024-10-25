using LibraryApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Data
{
    public class LibraryAppDbContext : DbContext
    {
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<BookTag> BookTags { get; set; }
        public DbSet<BookBorrow> BookBorrows { get; set; }


        public LibraryAppDbContext(DbContextOptions<LibraryAppDbContext> options) : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Subcategory)
                .WithMany(sc => sc.Books)
                .HasForeignKey(b => b.SubcategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<BookBorrow>()
                .HasOne(bb => bb.Customer)
                .WithMany(c => c.BookBorrows)
                .HasForeignKey(bb => bb.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<AppUser>().HasData(
                new AppUser
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "johndoe@example.com",
                    PasswordHash = "hashedpassword1", // Use a hashed password in real scenarios
                    PhoneNumber = "+123456789",
                    Role = "Customer", // Role as Customer
                    Birthdate = new DateOnly(1990, 1, 1),
                    IsDeleted = false,
                    CreatedAt = DateTime.UtcNow,
                    LastUpdatedAt = DateTime.UtcNow
                },
                new AppUser
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Smith",
                    Email = "janesmith@example.com",
                    PasswordHash = "hashedpassword2", // Use a hashed password in real scenarios
                    PhoneNumber = "+987654321",
                    Role = "Employee", // Role as Employee
                    Birthdate = new DateOnly(1985, 6, 15),
                    IsDeleted = false,
                    CreatedAt = DateTime.UtcNow,
                    LastUpdatedAt = DateTime.UtcNow
                },
                new AppUser
                {
                    Id = 3,
                    FirstName = "Alice",
                    LastName = "Johnson",
                    Email = "aliceauthor@example.com",
                    PasswordHash = "hashedpassword3", // Use a hashed password in real scenarios
                    PhoneNumber = "+192837465",
                    Role = "Author", // Role as Author
                    Birthdate = new DateOnly(1982, 10, 20),
                    IsDeleted = false,
                    CreatedAt = DateTime.UtcNow,
                    LastUpdatedAt = DateTime.UtcNow
                }
            );

            // Seeding Author data
            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    Id = 1,
                    AppUserId = 3 // Alice Johnson (AppUser with Author role)
                }
            );

            // Seeding Customer data
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    AppUserId = 1 // John Doe (AppUser with Customer role)
                }
            );

            // Seeding Employee data
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    Title = "Library Manager",
                    AppUserId = 2 // Jane Smith (AppUser with Employee role)
                }
            );

            // Seeding Category data
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Programming",
                    Description = "Books related to programming languages and software development."
                },
                new Category
                {
                    Id = 2,
                    Name = "Fiction",
                    Description = "Novels and stories that are imaginative and not based on real events."
                },
                new Category
                {
                    Id = 3,
                    Name = "Non-Fiction",
                    Description = "Books that are factual and based on real events and information."
                }
            );

            // Seeding Subcategory data
            modelBuilder.Entity<Subcategory>().HasData(
                new Subcategory
                {
                    Id = 1,
                    Name = "C# Programming",
                    CategoryId = 1 // Linking to "Programming" category
                },
                new Subcategory
                {
                    Id = 2,
                    Name = "Web Development",
                    CategoryId = 1 // Linking to "Programming" category
                },
                new Subcategory
                {
                    Id = 3,
                    Name = "Fantasy",
                    CategoryId = 2 // Linking to "Fiction" category
                },
                new Subcategory
                {
                    Id = 4,
                    Name = "Biography",
                    CategoryId = 3 // Linking to "Non-Fiction" category
                }
            );

            // Seeding Tag data
            modelBuilder.Entity<Tag>().HasData(
                new Tag
                {
                    Id = 1,
                    Name = "C#",
                    CreatedAt = DateTime.UtcNow
                },
                new Tag
                {
                    Id = 2,
                    Name = "ASP.NET",
                    CreatedAt = DateTime.UtcNow
                },
                new Tag
                {
                    Id = 3,
                    Name = "Web Development",
                    CreatedAt = DateTime.UtcNow
                },
                new Tag
                {
                    Id = 4,
                    Name = "Fantasy",
                    CreatedAt = DateTime.UtcNow
                },
                new Tag
                {
                    Id = 5,
                    Name = "Biography",
                    CreatedAt = DateTime.UtcNow
                }
            );

            // Seeding Book data
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "Mastering C#",
                    Description = "An advanced guide to C# programming.",
                    AuthorId = 1, // Alice Johnson is the author (AuthorId = 1)
                    CategoryId = 1, // Programming category
                    SubcategoryId = 1, // Subcategory "C# Programming"
                    PublishedDate = new DateOnly(2019, 3, 12),
                    CreatedAt = DateTime.UtcNow
                },
                new Book
                {
                    Id = 2,
                    Title = "ASP.NET Core in Action",
                    Description = "A practical guide to building web applications using ASP.NET Core.",
                    AuthorId = 1, // Alice Johnson is the author (AuthorId = 1)
                    CategoryId = 1, // Programming category
                    SubcategoryId = 2, // Subcategory "Web Development"
                    PublishedDate = new DateOnly(2020, 7, 25),
                    CreatedAt = DateTime.UtcNow
                }
            );

            // Seeding BookTag data for many-to-many relationships
            modelBuilder.Entity<BookTag>().HasData(
                new BookTag
                {
                    Id = 1,
                    BookId = 1, // Mastering C# tagged with "C#"
                    TagId = 1
                },
                new BookTag
                {
                    Id = 2,
                    BookId = 1, // Mastering C# tagged with "ASP.NET"
                    TagId = 2
                },
                new BookTag
                {
                    Id = 3,
                    BookId = 2, // ASP.NET Core in Action tagged with "ASP.NET"
                    TagId = 2
                },
                new BookTag
                {
                    Id = 4,
                    BookId = 2, // ASP.NET Core in Action tagged with "Web Development"
                    TagId = 3
                }
            );

            // Seeding BookBorrow data
            modelBuilder.Entity<BookBorrow>().HasData(
                new BookBorrow
                {
                    Id = 1,
                    CustomerId = 1, // John Doe
                    BookId = 1, // Mastering C#
                    CreatedAt = DateTime.UtcNow,
                    ExpiryDate = DateTime.UtcNow.AddDays(14) // 2-week loan period
                },
                new BookBorrow
                {
                    Id = 2,
                    CustomerId = 1, // John Doe
                    BookId = 2, // ASP.NET Core in Action
                    CreatedAt = DateTime.UtcNow,
                    ExpiryDate = DateTime.UtcNow.AddDays(14) // 2-week loan period
                }
            );



        }
    }
}
