using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Nirdeshika.Infrastructure.Data;
internal class ConnectionFactory(IConfiguration configuration) : IConnectionFactory
{
    private readonly string _connectionString = configuration.GetConnectionString("NirdeshikaConnnection") ?? string.Empty;
    
    public IDbConnection CreateConnection()
        => new SqlConnection(_connectionString);
}