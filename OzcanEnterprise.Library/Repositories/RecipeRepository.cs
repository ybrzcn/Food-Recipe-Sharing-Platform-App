using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OzcanEnterprise.Library.AppDbContexts;
using OzcanEnterprise.Library.Dtos;
using OzcanEnterprise.Library.Entities;
using OzcanEnterprise.Library.Interfaces;

namespace OzcanEnterprise.Library.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly MainDbContext _mainDbContext;
        private readonly IMapper _mapper;

        public RecipeRepository(MainDbContext mainDbContext, IMapper mapper)
        {
            _mainDbContext = mainDbContext;
            _mapper = mapper;
        }

        public async Task CreateAsync(RecipeDto dto)
        {
            var value = _mapper.Map<Recipe>(dto);
            await _mainDbContext.AddAsync(value);
            await SaveAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var value = _mapper.Map<Recipe>(id);
            if (value != null)
            {
                _mainDbContext.Remove(value);
                await SaveAsync();
            }
        }

        public async Task<IEnumerable<RecipeDto>> GetAllAsync()
        {
            return await _mainDbContext.Recipes
                .OrderBy(x => x.Title)
                .Select(x => _mapper.Map<RecipeDto>(x))
                .ToListAsync();
        }

        public async Task<RecipeDto?> GetByIdAsync(Guid id)
        {
            var value = await _mainDbContext.Recipes.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<RecipeDto?>(value);
        }

        public async Task<IEnumerable<RecipeDto>> GetRecipesByAuthorIdAsync(Guid authorId)
        {
            return await _mainDbContext.Recipes
                .Where(x => x.AuthorId == authorId)
                .Select(x => _mapper.Map<RecipeDto>(x))
                .ToListAsync();
        }

        public async Task<IEnumerable<RecipeDto>> GetRecipesByCategoryIdAsync(Guid categoryId)
        {
            return await _mainDbContext.Recipes
                .Where(x => x.CategoryId == categoryId)
                .Select(x => _mapper.Map<RecipeDto>(x))
                .ToListAsync();
        }

        public async Task SaveAsync()
        {
            await _mainDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(RecipeDto dto)
        {
            var value = _mapper.Map<RecipeDto>(dto);
            _mainDbContext.Update(value);
            await SaveAsync();
        }
    }
}
