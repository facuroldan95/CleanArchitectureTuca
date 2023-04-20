
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class RepositoryBaseMongoDb<T> : IAsyncRepositoryMongoDb<T> where T: EntityBase
    {
        private readonly IMongoDbContext _context;
        private readonly IMongoCollection<T> _dbSet;
        public RepositoryBaseMongoDb(IMongoDbContext context)
        {
            _context = context;
            _dbSet = _context.GetCollection<T>();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _dbSet.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.Find(x => true).ToListAsync();
        }
        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.InsertOneAsync(entity);
            return entity;
        }
        public async Task<bool> UpdateAsync(T entity)
        {
            var updateResult = await _dbSet.ReplaceOneAsync(x => x.Id == entity.Id, entity);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _context.GetCollection<T>().DeleteOneAsync(x => x.Id == id);
            return result.DeletedCount > 0;
        }


    }
}
