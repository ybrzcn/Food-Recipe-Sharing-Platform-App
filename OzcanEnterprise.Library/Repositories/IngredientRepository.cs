using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OzcanEnterprise.Library.AppDbContexts;
using OzcanEnterprise.Library.Dtos;
using OzcanEnterprise.Library.Entities;
using OzcanEnterprise.Library.Interfaces;

namespace OzcanEnterprise.Library.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly MainDbContext _mainDbContext;
        private readonly IMapper _mapper;

        public IngredientRepository(MainDbContext mainDbContext, IMapper mapper)
        {
            _mainDbContext = mainDbContext;
            _mapper = mapper;
        }

        public async Task CreateAsync(IngredientDto dto)
        {
            var value = _mapper.Map<Ingredient>(dto);
            await _mainDbContext.AddAsync(value);
            await SaveAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var value = _mapper.Map<Ingredient>(id);
            if (value != null)
            {
                _mainDbContext.Remove(_mapper.Map<Ingredient>(value));
                await SaveAsync();
            }
        }

        public async Task<IEnumerable<IngredientDto>> GetAllAsync()
        {
            return await _mainDbContext.Ingredients
                .OrderBy(x => x.CreatedDate)
                .Select(x => _mapper.Map<IngredientDto>(x))
                .ToListAsync();
        }

        public async Task<IngredientDto?> GetByIdAsync(Guid id)
        {
            var value = await _mainDbContext.Ingredients.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<IngredientDto?>(value);
        }

        public async Task<IEnumerable<IngredientDto>> GetIngredientsByRecipeIdAsync(Guid recipeId)
        {
            return await _mainDbContext.Ingredients
                .Where(x => x.RecipeId == recipeId)
                .Select(x => _mapper.Map<IngredientDto>(x))
                .ToListAsync();
        }

        public async Task SaveAsync()
        {
            await _mainDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(IngredientDto dto)
        {
            var value = _mapper.Map<CommentDto>(dto);
            _mainDbContext.Update(value);
            await SaveAsync();
        }
    }
}
