using AutoMapper;
using LibraryApp.API.DTOs.Requests;
using LibraryApp.API.DTOs.Responses;
using LibraryApp.Domain.Models;

namespace LibraryApp.API.Profiles
{
    public class BookBorrowProfile : Profile
    {
        public BookBorrowProfile()
        {
            CreateMap<PostBookBorrowRequest, BookBorrow>();
            CreateMap<BookBorrow,GetBookBorrowResponse>();
        }
    }
}
