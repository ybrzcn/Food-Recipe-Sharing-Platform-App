using OzcanEnterprise.Library.Dtos;
using OzcanEnterprise.Library.Entities;
using OzcanEnterprise.Library.Interfaces;

public interface IRatingRepository : IBaseRepository<Rating, RatingDto>
{
    Task<IEnumerable<RatingDto>> GetRatingsByRecipeIdAsync(Guid recipeId);
    Task<IEnumerable<RatingDto>> GetRatingsByUserIdAsync(Guid userId);
}