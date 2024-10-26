﻿using AutoMapper;
using LibraryApp.API.DTOs.Requests;
using LibraryApp.API.DTOs.Responses;
using LibraryApp.Domain.Models;

namespace LibraryApp.API.Profiles
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<PostCategoryRequest, Category>(); 
            CreateMap<Category, GetCategoryResponse>();
        }
    }
}
