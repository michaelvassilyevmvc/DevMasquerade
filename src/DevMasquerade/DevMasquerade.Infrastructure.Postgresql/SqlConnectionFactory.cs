using System.Data;
using DevMasquerade.Application.Database;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace DevMasquerade.Infrastructure.Postgresql;

public class SqlConnectionFactory : ISqlConnectionFactory
{
    private readonly IConfiguration _configuration;

    public SqlConnectionFactory(IConfiguration configuration) => _configuration = configuration;

    public IDbConnection Create()
    {
        var connectionString = _configuration.GetConnectionString("Database");
        return new NpgsqlConnection(connectionString);
    }
}