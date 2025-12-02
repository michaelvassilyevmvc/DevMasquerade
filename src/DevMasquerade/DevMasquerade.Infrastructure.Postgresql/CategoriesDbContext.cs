using DevMasquerade.Domain.Costumes;
using Microsoft.EntityFrameworkCore;

namespace DevMasquerade.Infrastructure.Postgresql;

public class CategoriesDbContext: DbContext
{
    public DbSet<Category> Categories { get; set; }
}