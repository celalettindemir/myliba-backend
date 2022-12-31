using Microsoft.Extensions.DependencyInjection;

namespace Case.Service;

public static class ServiceRegister
{
    public static IServiceCollection CaseServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IPersonalService), typeof(PersonalService));

        return services;
    }
}