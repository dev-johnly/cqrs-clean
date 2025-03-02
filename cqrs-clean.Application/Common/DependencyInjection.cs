using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace cqrs_clean.Application.Common;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        // Add other application-layer services here (e.g., validators, domain event handlers, etc.)

        return services;
    }
}