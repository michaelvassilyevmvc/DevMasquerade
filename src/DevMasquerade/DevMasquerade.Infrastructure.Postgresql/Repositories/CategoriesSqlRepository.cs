using Dapper;
using DevMasquerade.Application.Costumes.Categories;
using DevMasquerade.Domain.Costumes;

namespace DevMasquerade.Infrastructure.Postgresql.Repositories;

public class CategoriesSqlRepository : ICategoriesRepository
{
    private readonly SqlConnectionFactory _sqlConnectionFactory;

    public CategoriesSqlRepository(SqlConnectionFactory sqlConnectionFactory) =>
        _sqlConnectionFactory = sqlConnectionFactory;

    public Task<Category?> GetByIdAsync(Guid id, CancellationToken cancellationToken) =>
        throw new NotImplementedException();

    public Task<List<Category>> GetAllAsync(CancellationToken cancellationToken) => throw new NotImplementedException();

    public async Task<Guid> AddAsync(Category category, CancellationToken cancellationToken)
    {
        const string sql = """
                           INSERT INTO categories (id, name, slug, description, parent_id)
                           VALUES (@id, @name, @slug, @description, @parentId)
                           """;
        using var connection = _sqlConnectionFactory.Create();
        await connection.ExecuteAsync(
            sql,
            new
            {
                Id = category.Id,
                Name = category.Name,
                Slug = category.Slug,
                Description = category.Description,
                ParentId = category.ParentId,
            });
        return category.Id;
    }

    public Task<bool> UpdateAsync(Category category, CancellationToken cancellationToken) =>
        throw new NotImplementedException();

    public Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken) => throw new NotImplementedException();
}