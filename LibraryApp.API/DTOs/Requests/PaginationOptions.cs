using LibraryApp.Domain.Common.Interfaces;

namespace LibraryApp.API.DTOs.Requests
{
    public class PaginationOptions : IPaginationOptions
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
