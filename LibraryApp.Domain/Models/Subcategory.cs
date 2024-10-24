using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Domain.Models
{
    public class Subcategory
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public virtual List<Book> Books { get; set; } = [];
    }
}
