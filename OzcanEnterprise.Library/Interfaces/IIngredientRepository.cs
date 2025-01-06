using OzcanEnterprise.Library.Dtos;
using OzcanEnterprise.Library.Entities;

namespace OzcanEnterprise.Library.Interfaces
{
    public interface IIngredientRepository : IBaseRepository<Ingredient, IngredientDto>
    {
        Task<IEnumerable<IngredientDto>> GetIngredientsByRecipeIdAsync(Guid recipeId);
    }
}
