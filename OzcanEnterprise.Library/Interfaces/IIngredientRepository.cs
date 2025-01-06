using OzcanEnterprise.Library.Entities;

namespace OzcanEnterprise.Library.Interfaces
{
    public interface IIngredientRepository : IBaseRepository<Ingredient>
    {
        Task<IEnumerable<Ingredient>> GetIngredientsByRecipeIdAsync(Guid recipeId);
    }
}
