using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OzcanEnterprise.Library.AppDbContexts;
using OzcanEnterprise.Library.Dtos;
using OzcanEnterprise.Library.Entities;
using OzcanEnterprise.Library.Interfaces;

namespace OzcanEnterprise.Library.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MainDbContext _mainDbContext;
        private readonly IMapper _mapper;

        public CategoryRepository(MainDbContext mainDbContext, IMapper mapper)
        {
            _mainDbContext = mainDbContext;
            _mapper = mapper;
        }

        public async Task CreateAsync(CategoryDto dto)
        {
            var value = _mapper.Map<Category>(dto);
            await _mainDbContext.AddAsync(value);
            await SaveAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var value = await GetByIdAsync(id);
            if (value != null)
            {
                _mainDbContext.Remove(_mapper.Map<Category>(value));
                await SaveAsync();
            }
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            return await _mainDbContext.Categories
                .OrderBy(c => c.Name)
                .Select(c => _mapper.Map<CategoryDto>(c))
                .ToListAsync();
        }

        public async Task<CategoryDto?> GetByIdAsync(Guid id)
        {
            var value = await _mainDbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<CategoryDto>(value);
        }

        public async Task<CategoryDto?> GetCategoryByNameAsync(string name)
        {
            var value = await _mainDbContext.Categories
                .FirstOrDefaultAsync(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            return _mapper.Map<CategoryDto>(value);
        }

        public async Task SaveAsync()
        {
            await _mainDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(CategoryDto dto)
        {
            var value = _mapper.Map<Category>(dto);
            _mainDbContext.Update(value);
            await SaveAsync();
        }
    }
}