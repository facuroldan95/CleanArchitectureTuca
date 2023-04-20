﻿using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface IStreamerRepository : IAsyncRepositoryMongoDb<Streamer>
    {
    }
}
