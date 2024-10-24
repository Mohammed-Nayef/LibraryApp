using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Domain.Models
{
    public  class BookBorrow
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }
        public int BookId { get; set; }
        public virtual Book? Book { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
