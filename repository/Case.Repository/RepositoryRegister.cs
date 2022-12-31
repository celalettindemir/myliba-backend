using Microsoft.Extensions.DependencyInjection;

namespace Case.Repository;

public static class RepositoryRegister
{
    public static IServiceCollection CaseRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        return services;
    }

}