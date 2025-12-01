using DevMasquerade.Domain.Costumes;

namespace DevMasquerade.Application.Costumes.Costumes;

public interface ICostumesRepository
{
    Task<Costume?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<List<Costume>> GetAllAsync(CancellationToken cancellationToken);
    Task<Guid> AddAsync(Costume costume, CancellationToken cancellationToken);
    Task<bool> UpdateAsync(Costume costume, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task<Guid> SaveChangesAsync(CancellationToken cancellationToken);
}