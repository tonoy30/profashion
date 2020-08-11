using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace profashion.core.Mongo
{
    public static class Extensions
    {
        public static void AddMongo(this IServiceCollection service, IConfiguration configuration)
        {
            service.Configure<MongoOptions>(configuration.GetSection(nameof(MongoOptions)));
            service.AddSingleton<MongoClient>(c =>
            {
                var options = c.GetService<IOptions<MongoOptions>>();
                return new MongoClient(options.Value.ConnectionString);
            });
            service.AddScoped<IMongoDatabase>(c =>
            {
                var options = c.GetService<IOptions<MongoOptions>>();
                var client = c.GetService<MongoClient>();
                return client.GetDatabase(options.Value.Database);
            });
            service.AddScoped<IDatabaseInitializer, MongoInitializer>();
            service.AddScoped<IDatabaseSeeder, MongoSeeder>();
        }
    }
}