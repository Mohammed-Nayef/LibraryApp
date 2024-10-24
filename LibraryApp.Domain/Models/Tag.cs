using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Domain.Models
{
    public class Tag
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public required string Name { get; set; }
        public virtual List<BookTag> BookTags { get; set; } = [];
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
