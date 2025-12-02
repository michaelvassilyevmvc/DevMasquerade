using DevMasquerade.Application.Costumes.Categories;
using DevMasquerade.Application.Costumes.Costumes;
using DevMasquerade.Infrastructure.Postgresql.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DevMasquerade.Infrastructure.Postgresql;

public static class DependencyInjection
{
    public static IServiceCollection AddPostgresqlInfrastructure(this IServiceCollection services)
    {
        // services.AddSingleton<ISqlConnectionFactory, SqlConnectionFactory>();
        services.AddScoped<ICategoriesRepository, CategoriesEFCoreRepository>();
        services.AddDbContext<CategoriesDbContext>();
        services.AddScoped<ICostumesRepository, CostumeEFCoreRepository>();
        services.AddDbContext<CostumesDbContext>();
        return services;
    }
}