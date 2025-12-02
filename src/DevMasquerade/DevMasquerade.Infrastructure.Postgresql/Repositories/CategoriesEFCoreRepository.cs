using DevMasquerade.Application.Costumes.Categories;
using DevMasquerade.Domain.Costumes;
using Microsoft.EntityFrameworkCore;

namespace DevMasquerade.Infrastructure.Postgresql.Repositories;

public class CategoriesEFCoreRepository : ICategoriesRepository
{
    private readonly CategoriesDbContext _dbContext;

    public CategoriesEFCoreRepository(CategoriesDbContext dbContext) => _dbContext = dbContext;


    public async Task<Category?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var category = await _dbContext.Categories
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        return category;
    }

    public async Task<List<Category>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Categories.ToListAsync(cancellationToken);
    }

    public async Task<Guid> AddAsync(Category category, CancellationToken cancellationToken)
    {
        await _dbContext.Categories.AddAsync(category, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return category.Id;
    }

    public async Task<bool> UpdateAsync(Category category, CancellationToken cancellationToken)
    {
        var entry = _dbContext.Categories.Update(category);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return entry.Entity == category;
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var category = await _dbContext.Categories.FindAsync(id, cancellationToken);
        _dbContext.Categories.Remove(category);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return category != null;
    }
}