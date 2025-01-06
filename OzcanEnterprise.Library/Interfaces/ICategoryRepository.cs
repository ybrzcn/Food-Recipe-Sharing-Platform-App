using OzcanEnterprise.Library.Entities;

namespace OzcanEnterprise.Library.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<Category?> GetCategoryByNameAsync(string name);
    }
}
