using AutoMapper;
using LibraryApp.API.DTOs.Requests;
using LibraryApp.API.DTOs.Responses;
using LibraryApp.Domain.Models;

namespace LibraryApp.API.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<PostCustomerRequest, Customer>()
                .ForMember(dest => dest.AppUser, opt => opt.MapFrom(src => new AppUser
                {
                    Email = src.Email,
                    FirstName = src.FirstName,
                    LastName = src.LastName,
                    PasswordHash = src.PasswordHash,
                    PhoneNumber = src.PhoneNumber,
                    Role = "Customer",
                    Birthdate = src.Birthdate,
                }));

            CreateMap<Customer, GetCustomerResponse>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.AppUser.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.AppUser.LastName))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.AppUser.PhoneNumber))
                .ForMember(d => d.Email, opt => opt.MapFrom(s => s.AppUser.Email))
                .ForMember(d => d.Birthdate, opt => opt.MapFrom(s => s.AppUser.Birthdate));
        }
    }
}
