using OzcanEnterprise.Library.Dtos;
using OzcanEnterprise.Library.Entities;

namespace OzcanEnterprise.Library.Interfaces
{
    public interface IUserRepository : IBaseRepository<User, UserDto>
    {
        Task<IEnumerable<UserDto>> GetUserByEmailAsync(string email);
    }
}
