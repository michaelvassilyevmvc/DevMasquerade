namespace DevMasquerade.Infrastructure.Postgresql.Seeders;

public class CategoriesSeeder : ISeeder
{
    private readonly CategoriesDbContext _dbContext;

    public CategoriesSeeder(CategoriesDbContext dbContext) => _dbContext = dbContext;

    public Task SeedAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}