using DevMasquerade.Domain.Costumes;

namespace DevMasquerade.Application.Costumes.Categories;

public interface ICategoriesRepository
{
    Task<Category?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<List<Category>> GetAllAsync(CancellationToken cancellationToken);
    Task<Guid> AddAsync(Category category, CancellationToken cancellationToken);
    Task<bool> UpdateAsync(Category category, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task<Guid> SaveChangesAsync(CancellationToken cancellationToken);
}