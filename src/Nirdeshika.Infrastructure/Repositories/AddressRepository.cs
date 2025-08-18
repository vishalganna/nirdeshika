using Dapper;
using Microsoft.Extensions.Logging;
using Nirdeshika.Application.Repositories;
using Nirdeshika.Domain.Entities;
using Nirdeshika.Infrastructure.Data;

namespace Nirdeshika.Infrastructure.Repositories;
public class AddressRepository(
    IConnectionFactory connectionFactory,
    ILogger<AddressRepository> logger
    ) : IAddressRepository
{
    public async Task<IEnumerable<Address>> GetAllAsync()
    {
        try
        {
            using var connection = connectionFactory.CreateConnection();
            return await connection.QueryAsync<Address>("SELECT * FROM Addresses");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error while connecting to the database: {Message}", ex.Message);
            throw;
        }
    }
}
