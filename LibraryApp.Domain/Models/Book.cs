using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Domain.Models
{
    public class Book
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }


        public int AuthorId { get; set; }
        public virtual Author? Author { get; set; }

        public int CategoryId {  get; set; }
        public virtual Category? Category { get; set; }

        public int SubcategoryId {  get; set; }
        public virtual Subcategory? Subcategory { get; set; }
        public virtual List<BookTag> BookTags { get; set; } = [];
        public virtual List<BookBorrow> Borrows { get; set; } = [];
        public DateOnly PublishedDate{ get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
