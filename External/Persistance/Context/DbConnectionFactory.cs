using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Persistance.Context;

public class DbConnectionFactory : IDapperContext
{
    private readonly IConfiguration _configuration;
    private readonly string? _connectionString;

    public DbConnectionFactory(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = string.IsNullOrEmpty(_configuration.GetConnectionString("DefaultConnection"))
           ? throw new ArgumentNullException("DefaultConnection", "Connection string is null or empty. Please check your configuration.")
           : _configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<SqlConnection> CreateConnection()
    {
        var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();
        return connection;
    }
}
