using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Domain.Models
{
    public class BookTag
    {
        public int Id { get; set; }
        public int TagId {  get; set; }
        public int BookId { get; set; }
    }
}
