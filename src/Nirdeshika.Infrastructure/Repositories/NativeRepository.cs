using Dapper;
using Microsoft.Extensions.Logging;
using Nirdeshika.Application.Repositories;
using Nirdeshika.Domain.Entities;
using Nirdeshika.Infrastructure.Data;

namespace Nirdeshika.Infrastructure.Repositories;
internal class NativeRepository(
    IConnectionFactory connectionFactory,
    ILogger<NativeRepository> logger
    ) : INativeRepository
{
    public async Task<IEnumerable<Native>> GetAllAsync()
    {
        try
        {
            using var connection = connectionFactory.CreateConnection();
            return await connection.QueryAsync<Native>("SELECT * FROM Natives");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error while connecting to the database: {Message}", ex.Message);
            throw;
        }
    }
}
