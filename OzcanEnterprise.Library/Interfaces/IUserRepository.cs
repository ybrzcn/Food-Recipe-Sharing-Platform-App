using OzcanEnterprise.Library.Entities;

namespace OzcanEnterprise.Library.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetUserByEmailAsync(string email);
    }
}
