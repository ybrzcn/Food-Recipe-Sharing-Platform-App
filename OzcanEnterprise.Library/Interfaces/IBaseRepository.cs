namespace OzcanEnterprise.Library.Interfaces
{
    public interface IBaseRepository<TEntity, TDto> where TEntity : class where TDto : class
    {
        Task<TDto?> GetByIdAsync(Guid id);
        Task<IEnumerable<TDto>> GetAllAsync();
        Task CreateAsync(TDto dto);
        Task UpdateAsync(TDto dto);
        Task DeleteAsync(Guid id);
        Task SaveAsync();
    }
}
