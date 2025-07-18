using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Nirdeshika.Infrastructure.Data;
internal class ConnectionFactory(
    IConfiguration configuration,
    ILogger<ConnectionFactory> logger
    ) : IConnectionFactory
{
    private readonly string _connectionString = configuration.GetConnectionString("NirdeshikaConnection") ?? string.Empty;

    public IDbConnection CreateConnection()
    {
        logger.LogInformation("Creating a new database connection with connection string: {ConnectionString}", _connectionString);
        return new SqlConnection(_connectionString);
    }
}