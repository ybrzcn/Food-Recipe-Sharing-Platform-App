using OzcanEnterprise.Library.Dtos;
using OzcanEnterprise.Library.Entities;

namespace OzcanEnterprise.Library.Interfaces
{
    public interface ICommentRepository : IBaseRepository<Comment, CommentDto>
    {
        Task<IEnumerable<CommentDto>> GetCommentsByRecipeIdAsync(Guid recipeId);
        Task<IEnumerable<CommentDto>> GetCommentsByUserIdAsync(Guid userId);
    }
}
