using DevMasquerade.Application;
using DevMasquerade.Infrastructure.Postgresql;

namespace DevMasquerade.Web;

public static class DependencyInjection
{
    public static IServiceCollection AddProgramDependencies(this IServiceCollection services) => services
        .AddWebDependencies()
        .AddApplicationDependencies()
        .AddPostgresqlInfrastructure();

    private static IServiceCollection AddWebDependencies(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddOpenApi();
        return services;
    }
}