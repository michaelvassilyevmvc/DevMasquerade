using DevMasquerade.Domain.Costumes;
using Microsoft.EntityFrameworkCore;

namespace DevMasquerade.Infrastructure.Postgresql;

public class CostumesDbContext: DbContext
{
    public DbSet<Costume> Costumes { get; set; }
}