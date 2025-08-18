using Dapper;
using Microsoft.Extensions.Logging;
using Nirdeshika.Application.Repositories;
using Nirdeshika.Domain.Entities;
using Nirdeshika.Infrastructure.Data;

namespace Nirdeshika.Infrastructure.Repositories;
internal class SurnameRepository(
    IConnectionFactory connectionFactory,
    ILogger<SurnameRepository> logger
    ) : ISurnameRepository
{
    public async Task<IEnumerable<Surname>> GetAllAsync()
    {
        try
        {
            using var connection = connectionFactory.CreateConnection();
            return await connection.QueryAsync<Surname>("SELECT * FROM Surnames");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error while connecting to the database: {Message}", ex.Message);
            throw;
        }
    }
}
