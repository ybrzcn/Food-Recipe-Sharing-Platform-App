using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OzcanEnterprise.Library.AppDbContexts;
using OzcanEnterprise.Library.Dtos;
using OzcanEnterprise.Library.Entities;
using OzcanEnterprise.Library.Interfaces;

namespace OzcanEnterprise.Library.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MainDbContext _mainDbContext;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserRepository(MainDbContext mainDbContext, IMapper mapper, IPasswordHasher<User> passwordHasher)
        {
            _mainDbContext = mainDbContext;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task CreateAsync(UserDto dto)
        {
            var value = _mapper.Map<User>(dto);
            value.PasswordHash = _passwordHasher.HashPassword(value, dto.Password);
            await _mainDbContext.AddAsync(value);
            await SaveAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var value = _mapper.Map<User>(id);
            if (value != null)
            {
                _mainDbContext.Remove(value);
                await SaveAsync();
            }
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            return await _mainDbContext.Users
                .OrderBy(x => x.UserName)
                .Select(x => _mapper.Map<UserDto>(x))
                .ToListAsync();
        }

        public async Task<UserDto?> GetByIdAsync(Guid id)
        {
            var value = await _mainDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<UserDto?>(value);
        }

        public async Task<IEnumerable<UserDto>> GetUserByEmailAsync(string email)
        {
            return await _mainDbContext.Users
                .Where(x => x.Email == email)
                .Select(x => _mapper.Map<UserDto>(x))
                .ToListAsync();
        }

        public async Task SaveAsync()
        {
            await _mainDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserDto dto)
        {
            var value = _mapper.Map<CommentDto>(dto);
            _mainDbContext.Update(value);
            await SaveAsync();
        }
    }
}
