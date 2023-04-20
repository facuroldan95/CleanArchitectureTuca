using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Contracts;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson.Serialization;

namespace CleanArchitecture.Infrastructure.Persistence.MongoDb
{
    public class StreamerMongoDbContext: IMongoDbContext
    {

        private readonly IMongoDatabase _database;

        public StreamerMongoDbContext(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("ConnectionString");
            string databaseName = configuration["DatabaseName"];
            var mongoClient = new MongoClient(connectionString);
            _database = mongoClient.GetDatabase(databaseName);
        }

        public IMongoCollection<TEntity> GetCollection<TEntity>() where TEntity : EntityBase
        {
            return _database.GetCollection<TEntity>(typeof(TEntity).Name.ToLower());
        }
    }
}
