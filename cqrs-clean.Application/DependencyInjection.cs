using cqrs_clean.Application.MappingProfile;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace cqrs_clean.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        // Add other application-layer services here (e.g., validators, domain event handlers, etc.)
        TypeAdapterConfig.GlobalSettings.Scan(typeof(MappingConfig).Assembly);
        services.AddScoped<IMapper, Mapper>();
        return services;
    }
}