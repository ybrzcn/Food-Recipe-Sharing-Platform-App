﻿using AutoMapper;
using OzcanEnterprise.Library.Dtos;
using OzcanEnterprise.Library.Entities;

namespace OzcanEnterprise.Library.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping() 
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<Ingredient, IngredientDto>().ReverseMap();
            CreateMap<Rating, RatingDto>().ReverseMap();
            CreateMap<Recipe, RecipeDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
