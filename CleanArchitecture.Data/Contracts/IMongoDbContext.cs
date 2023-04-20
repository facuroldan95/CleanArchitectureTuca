
using CleanArchitecture.Domain;
using MongoDB.Driver;

namespace CleanArchitecture.Infrastructure.Contracts
{
    public interface IMongoDbContext
    {
        IMongoCollection<TEntity> GetCollection<TEntity>() where TEntity : class, IEntity;
    }
}
