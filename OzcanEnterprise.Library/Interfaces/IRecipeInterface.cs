using OzcanEnterprise.Library.Dtos;
using OzcanEnterprise.Library.Entities;

namespace OzcanEnterprise.Library.Interfaces
{
    public interface IRecipeRepository : IBaseRepository<Recipe, RecipeDto>
    {
        Task<IEnumerable<RecipeDto>> GetRecipesByCategoryIdAsync(Guid categoryId);
        Task<IEnumerable<RecipeDto>> GetRecipesByAuthorIdAsync(Guid authorId);
    }
}
