using AutoMapper;
using LibraryApp.API.DTOs.Requests;
using LibraryApp.API.DTOs.Responses;
using LibraryApp.Domain.Models;

namespace LibraryApp.API.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<PostBookRequest, Book>();
            CreateMap<Book, GetBookResponse>();
        }
    }
}
