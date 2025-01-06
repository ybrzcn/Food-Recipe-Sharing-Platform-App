using OzcanEnterprise.Library.Dtos;
using OzcanEnterprise.Library.Entities;

namespace OzcanEnterprise.Library.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category, CategoryDto>
    {
        Task<CategoryDto?> GetCategoryByNameAsync(string name);
    }
}
