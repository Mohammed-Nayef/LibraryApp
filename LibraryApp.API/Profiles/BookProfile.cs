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
            CreateMap<PostBookRequest, Book>()
                .ForMember(dest => dest.BookTags,
                            opt => opt.MapFrom(
                                src => src.TagsIds.Select(
                                    id => new BookTag()
                                    {
                                        TagId = id
                                    })));

            CreateMap<Book, GetBookResponse>()
                .ForMember(d => d.CategoryName, opt => opt.MapFrom(s => s.Category!.Name))
                .ForMember(d => d.SubcategoryName, opt => opt.MapFrom(s => s.Subcategory!.Name))
                .ForMember(d => d.Tags, opt => opt.MapFrom(s => s.BookTags.Select(bt => bt.Tag!.Name)));

            CreateMap<PutBookRequest, Book>();


        }
    }
}
