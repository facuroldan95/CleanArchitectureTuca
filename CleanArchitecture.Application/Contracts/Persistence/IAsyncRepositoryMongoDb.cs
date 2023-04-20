
using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface IAsyncRepositoryMongoDb<T> where T : IEntity
    {
        Task<T> GetByIdAsync(string id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(string id);

    }
}
