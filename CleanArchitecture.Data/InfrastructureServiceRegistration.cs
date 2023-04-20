using CleanArchitecture.Application.Contracts.Infrastructure;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Contracts;
using CleanArchitecture.Infrastructure.Email;
using CleanArchitecture.Infrastructure.Persistence;
using CleanArchitecture.Infrastructure.Persistence.MongoDb;
using CleanArchitecture.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //SQL Server
            //services.AddDbContext<StreamerDbContext>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("ConnectionString"))
            //);

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IVideoRepository, VideoRepository>();
            services.AddScoped<IStreamerRepository, StreamerRepository>();

            services.AddScoped<IMongoDbContext, StreamerMongoDbContext>();

            services.AddScoped(typeof(IAsyncRepositoryMongoDb<>), typeof(RepositoryBaseMongoDb<>));

            BsonClassMap.RegisterClassMap<Streamer>(cm =>
            {
                cm.AutoMap();
                cm.SetIgnoreExtraElements(true);
            });

            BsonClassMap.RegisterClassMap<Video>(cm =>
            {
                cm.AutoMap();
                cm.SetIgnoreExtraElements(true);
            });

            BsonClassMap.RegisterClassMap<VideoActor>(cm =>
            {
                cm.AutoMap();
                cm.SetIgnoreExtraElements(true);
            });

            BsonClassMap.RegisterClassMap<Director>(cm =>
            {
                cm.AutoMap();
                cm.SetIgnoreExtraElements(true);
            });

            services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailService, EmailService>();

            return services;
        }

    }
}
