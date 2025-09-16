using Microsoft.Data.SqlClient;

namespace Persistance.Context;

public interface IDapperContext
{
    Task<SqlConnection> CreateConnection();
}
