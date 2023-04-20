using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Contracts;
using CleanArchitecture.Infrastructure.Persistence;
using MongoDB.Driver;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class StreamerRepository : RepositoryBaseMongoDb<Streamer>, IStreamerRepository
    {
        public StreamerRepository(IMongoDbContext context) : base(context)
        { }
    }
}
