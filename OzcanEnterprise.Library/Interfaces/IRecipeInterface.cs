using OzcanEnterprise.Library.Entities;

namespace OzcanEnterprise.Library.Interfaces
{
    public interface IRecipeInterface : IBaseRepository<Recipe>
    {
        Task<IEnumerable<Recipe>> GetRecipesByCategoryAsync(Guid categoryId);
    }
}
