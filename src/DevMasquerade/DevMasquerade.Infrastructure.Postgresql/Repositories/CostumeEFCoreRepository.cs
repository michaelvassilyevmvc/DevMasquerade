using DevMasquerade.Application.Costumes.Costumes;
using DevMasquerade.Domain.Costumes;

namespace DevMasquerade.Infrastructure.Postgresql.Repositories;

public class CostumeEFCoreRepository: ICostumesRepository
{
    private readonly CostumesDbContext _dbContext;

    public CostumeEFCoreRepository(CostumesDbContext dbContext) => _dbContext = dbContext;

    public Task<Costume?> GetByIdAsync(Guid id, CancellationToken cancellationToken) => throw new NotImplementedException();

    public Task<List<Costume>> GetAllAsync(CancellationToken cancellationToken) => throw new NotImplementedException();

    public Task<Guid> AddAsync(Costume costume, CancellationToken cancellationToken) => throw new NotImplementedException();

    public Task<bool> UpdateAsync(Costume costume, CancellationToken cancellationToken) => throw new NotImplementedException();

    public Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken) => throw new NotImplementedException();

    public Task<Guid> SaveChangesAsync(CancellationToken cancellationToken) => throw new NotImplementedException();
}