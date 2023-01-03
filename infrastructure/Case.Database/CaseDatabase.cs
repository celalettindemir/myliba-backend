using MongoDB.Driver;

namespace Case.Database;
using Microsoft.Extensions.DependencyInjection;

public static class CaseDatabase
{
    public static IServiceCollection CaseDatabaseConnection(this IServiceCollection services,MongoDbSettings mongoDbSettings)
    {
        var client = new MongoClient(mongoDbSettings.ConnectionString);
        services.AddSingleton<IMongoClient>(client);
        return services;
    }
}