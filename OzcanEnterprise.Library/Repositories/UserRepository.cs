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
            value.Id = Guid.NewGuid();
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

        public async Task<IEnumerable<UserDto>> GetUserByUserNameAsync(string userName)
        {
            return await _mainDbContext.Users
                .Where(x => x.UserName == userName)
                .Select(x => _mapper.Map<UserDto>(x))
                .ToListAsync();
        }

        public async Task<UserDto?> GetUserByUserNameForLoginAsync(string userName)
        {
            var user = await _mainDbContext.Users
                .FirstOrDefaultAsync(x => x.UserName == userName);

            if (user == null)
            {
                return null; // Kullanıcı bulunamazsa null döndür
            }

            var userDto = _mapper.Map<UserDto>(user);
            userDto.Password = user.PasswordHash;
            return userDto;
        }

        public async Task SaveAsync()
        {
            await _mainDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserDto dto)
        {
            var value = _mapper.Map<User>(dto);
            _mainDbContext.Update(value);
            await SaveAsync();
        }

        public async Task UpdateLastLoginDateAsync(Guid userId, DateTime lastLoginDate)
        {
            var user = await _mainDbContext.Users.FindAsync(userId);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found.");
            }

            user.LastLoginDate = lastLoginDate;
            await SaveAsync();
        }
    }
}
