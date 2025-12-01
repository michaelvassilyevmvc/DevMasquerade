using DevMasquerade.Contracts.Costumes.Costumes;
using DevMasquerade.Domain.Costumes;

namespace DevMasquerade.Application.Costumes.Costumes;

public interface ICostumesService
{
    Task<Costume?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<List<Costume>?> GetAllAsync(CancellationToken cancellationToken);
    Task<Costume> CreateAsync(CreateCostumeDto request, CancellationToken cancellationToken);
    Task<Costume> UpdateAsync(Guid id, UpdateCostumeDto request, CancellationToken cancellationToken);
    Task<Costume> DeleteAsync(Guid id, CancellationToken cancellationToken);
}