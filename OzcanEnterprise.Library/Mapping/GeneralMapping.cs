using AutoMapper;
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

            CreateMap<UserDto, User>();

            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.PasswordHash));
        }
    }
}
