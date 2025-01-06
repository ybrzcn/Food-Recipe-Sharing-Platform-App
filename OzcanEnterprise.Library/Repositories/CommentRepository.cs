using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OzcanEnterprise.Library.AppDbContexts;
using OzcanEnterprise.Library.Dtos;
using OzcanEnterprise.Library.Entities;
using OzcanEnterprise.Library.Interfaces;

namespace OzcanEnterprise.Library.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly MainDbContext _mainDbContext;
        private readonly IMapper _mapper;

        public CommentRepository(MainDbContext mainDbContext, IMapper mapper)
        {
            _mainDbContext = mainDbContext;
            _mapper = mapper;
        }

        public async Task CreateAsync(CommentDto dto)
        {
            var value = _mapper.Map<Comment>(dto);
            await _mainDbContext.AddAsync(value);
            await SaveAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var value = _mapper.Map<Comment>(id);
            if (value != null)
            {
                _mainDbContext.Remove(_mapper.Map<Comment>(value));
                await SaveAsync();
            }
        }

        public async Task<IEnumerable<CommentDto>> GetAllAsync()
        {
            return await _mainDbContext.Comments
                .OrderBy(x => x.CreatedDate)
                .Select(x => _mapper.Map<CommentDto>(x))
                .ToListAsync();
        }

        public async Task<CommentDto?> GetByIdAsync(Guid id)
        {
            var value = await _mainDbContext.Comments.FindAsync(id);
            return _mapper.Map<CommentDto?>(value);
        }

        public async Task<IEnumerable<CommentDto>> GetCommentsByRecipeIdAsync(Guid recipeId)
        {
            return await _mainDbContext.Comments
                .Where(x => x.RecipeId == recipeId)
                .Select(x => _mapper.Map<CommentDto>(x))
                .ToListAsync();
        }

        public async Task<IEnumerable<CommentDto>> GetCommentsByUserIdAsync(Guid userId)
        {
            return await _mainDbContext.Comments
                .Where(x => x.UserId == userId)
                .Select(x => _mapper.Map<CommentDto>(x))
                .ToListAsync();
        }

        public async Task SaveAsync()
        {
            await _mainDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(CommentDto dto)
        {
            var value = _mapper.Map<CommentDto>(dto);
            _mainDbContext.Update(value);
            await SaveAsync();
        }
    }
}
