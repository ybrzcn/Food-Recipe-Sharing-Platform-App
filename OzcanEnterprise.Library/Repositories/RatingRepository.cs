using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OzcanEnterprise.Library.AppDbContexts;
using OzcanEnterprise.Library.Dtos;
using OzcanEnterprise.Library.Entities;

namespace OzcanEnterprise.Library.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly MainDbContext _mainDbContext;
        private readonly IMapper _mapper;

        public RatingRepository(MainDbContext mainDbContext, IMapper mapper)
        {
            _mainDbContext = mainDbContext;
            _mapper = mapper;
        }

        public async Task CreateAsync(RatingDto dto)
        {
            var value = _mapper.Map<Rating>(dto);
            await _mainDbContext.AddAsync(value);
            await SaveAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var value = _mapper.Map<Rating>(id);
            if (value != null)
            {
                _mainDbContext.Remove(_mapper.Map<Rating>(value));
                await SaveAsync();
            }
        }

        public async Task<IEnumerable<RatingDto>> GetAllAsync()
        {
            return await _mainDbContext.Ratings
                .OrderBy(x => x.CreatedDate)
                .Select(x => _mapper.Map<RatingDto>(x))
                .ToListAsync();
        }

        public async Task<RatingDto?> GetByIdAsync(Guid id)
        {
            var value = await _mainDbContext.Ratings.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<RatingDto?>(value);
        }

        public async Task<IEnumerable<RatingDto>> GetRatingsByRecipeIdAsync(Guid recipeId)
        {
            return await _mainDbContext.Ratings
                .Where(x => x.RecipeId == recipeId)
                .Select(x => _mapper.Map<RatingDto>(x))
                .ToListAsync();
        }

        public async Task<IEnumerable<RatingDto>> GetRatingsByUserIdAsync(Guid userId)
        {
            return await _mainDbContext.Ratings
                .Where(x => x.UserId == userId)
                .Select(x => _mapper.Map<RatingDto>(x))
                .ToListAsync();
        }

        public async Task SaveAsync()
        {
            await _mainDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(RatingDto dto)
        {
            var value = _mapper.Map<RatingDto>(dto);
            _mainDbContext.Update(value);
            await SaveAsync();
        }
    }
}
