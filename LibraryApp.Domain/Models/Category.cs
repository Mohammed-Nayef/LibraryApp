using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Domain.Models
{
    public class Category
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string Description { get; set; } = "";
        public virtual List<Book> Books { get; set; } = [];
        public virtual List<Subcategory> Subcategories { get; set; } = [];
    }
}
