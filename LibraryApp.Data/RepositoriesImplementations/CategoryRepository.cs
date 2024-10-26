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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public List<Category> GetAllWithSubcategories()
        {
            return _dbContext.Set<Category>()
                .Include(c => c.Subcategories)
                .ToList();
        }

        public Category? GetWithSubcategories(int id)
        {
            return _dbContext.Set<Category>()
                .Include(c => c.Subcategories)
                .Where(c => c.Id == id)
                .FirstOrDefault();
        }
    }
}
