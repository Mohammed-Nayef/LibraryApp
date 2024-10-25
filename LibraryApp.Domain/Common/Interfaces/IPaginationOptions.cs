using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Domain.Common.Interfaces
{
    public interface IPaginationOptions
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

    }
}
