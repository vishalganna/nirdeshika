using Dapper;
using Microsoft.Extensions.Logging;
using Nirdeshika.Application.Repositories;
using Nirdeshika.Domain.Entities;
using Nirdeshika.Infrastructure.Data;

namespace Nirdeshika.Infrastructure.Repositories;
public class SectRepository(
    IConnectionFactory connectionFactory,
    ILogger<SectRepository> logger
    ) : ISectRepository
{
    public async Task<IEnumerable<Sect>> GetAllAsync()
    {
        try
        {
            using var connection = connectionFactory.CreateConnection();
            return await connection.QueryAsync<Sect>("SELECT * FROM Sects");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error while connecting to the database: {Message}", ex.Message);
            throw;
        }
    }
}
