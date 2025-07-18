using Dapper;
using Nirdeshika.Application.Repositories;
using Nirdeshika.Domain.Entities;
using Nirdeshika.Infrastructure.Data;

namespace Nirdeshika.Infrastructure.Repositories;
internal class SurnameRepository(IConnectionFactory connectionFactory) : ISurnameRepository
{
    public async Task<IEnumerable<Surname>> GetAllAsync()
    {
        using var connection = connectionFactory.CreateConnection();
        return await connection.QueryAsync<Surname>("SELECT * FROM Surnames");
    }
}
