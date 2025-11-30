using DevMasquerade.Contracts.Costumes.Categories;
using DevMasquerade.Domain.Costumes;

namespace DevMasquerade.Application.Costumes.Categories;

public interface ICategoriesService
{
    Task<Category> CreateAsync(CreateCategoryDto request, CancellationToken cancellationToken);
    Task<Category> UpdateAsync(Guid id, UpdateCategoryDto dto, CancellationToken cancellationToken);
    Task<Category> DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task<Category?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<List<Category>?> GetAllAsync(CancellationToken cancellationToken);
}