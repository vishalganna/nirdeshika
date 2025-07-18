using Dapper;
using Nirdeshika.Application.Repositories;
using Nirdeshika.Domain.Entities;
using Nirdeshika.Infrastructure.Data;

namespace Nirdeshika.Infrastructure.Repositories;
internal class RelationTypeRepository(IConnectionFactory connectionFactory) : IRelationTypeRepository
{
    public async Task<IEnumerable<RelationType>> GetAllAsync()
    {
        using var connection = connectionFactory.CreateConnection();
        return await connection.QueryAsync<RelationType>("SELECT * FROM RelationTypes");
    }

    public async Task<RelationType?> GetByIdAsync(int id)
    {
        using var connection = connectionFactory.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<RelationType>(
            "SELECT * FROM RelationTypes WHERE Id = @Id", new { Id = id });
    }
}
