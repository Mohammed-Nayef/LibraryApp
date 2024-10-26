using AutoMapper;
using LibraryApp.API.DTOs.Responses;
using LibraryApp.Domain.Models;

namespace LibraryApp.API.Profiles
{
    public class SubcategoryProfile : Profile
    {
        public SubcategoryProfile()
        {
            CreateMap<Subcategory,GetSubcategoryResponse>();
        }
    }
}
