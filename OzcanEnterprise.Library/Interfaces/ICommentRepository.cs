using OzcanEnterprise.Library.Entities;

namespace OzcanEnterprise.Library.Interfaces
{
    public interface ICommentRepository : IBaseRepository<Comment>
    {
        Task<IEnumerable<Comment>> GetCommentsByRecipeIdAsync(Guid recipeId);
    }
}
