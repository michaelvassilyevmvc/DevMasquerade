using System.Data;

namespace DevMasquerade.Application.Database;

public interface ISqlConnectionFactory
{
    IDbConnection Create();
}