using LibraryApp.Domain.Common.Interfaces;
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
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public List<Book> GetAllByPage(IPaginationOptions paginationOptions)
        {
            int skip = (paginationOptions.PageNumber - 1) * paginationOptions.PageSize;
            return _dbContext.Set<Book>()
                .Skip(skip)
                .Include(b => b.Category)
                .Include(b => b.Subcategory)
                .Include(b => b.Author)
                .Include(b => b.BookTags)
                .ThenInclude(bt => bt.Tag)
                .Take(paginationOptions.PageSize)
                .ToList();
        }

        public List<Book> GetByCategoryAndSubcategory(int categoryId, int subcategoryId)
        {
            return _dbContext.Set<Book>()
                .Include(b => b.Category)
                .Include(b => b.Subcategory)
                .Include(b => b.Author)
                .Include(b => b.BookTags)
                .ThenInclude(bt => bt.Tag)
                .Where(b => b.CategoryId == categoryId && b.SubcategoryId == subcategoryId)
                .ToList();
        }

        public List<Book> GetByCategoryId(int id)
        {
            return _dbContext.Set<Book>()
                .Include(b => b.Category)
                .Include(b => b.Subcategory)
                .Include(b => b.Author)
                .Include(b => b.BookTags)
                .ThenInclude(bt => bt.Tag)
                .Where(b => b.CategoryId == id)
                .ToList();
        }

        public List<Book> GetByCategoryName(string categoryName)
        {
            return _dbContext.Set<Book>()
                .Include(b => b.Category)
                .Include(b => b.Subcategory)
                .Include(b => b.Author)
                .Include(b => b.BookTags)
                .ThenInclude(bt => bt.Tag)
                .Where(b => b.Category!.Name.Contains(categoryName))
                .ToList();
        }

        public Book? GetWithTFullNavigations(int id)
        {
            return _dbContext.Set<Book>()
                .Include(b => b.Category)
                .Include(b => b.Subcategory)
                .Include(b => b.Author)
                .Include(b => b.BookTags)
                .ThenInclude(bt => bt.Tag)
                .Where(b => b.Id == id)
                .FirstOrDefault();
                
        }
    }
}
