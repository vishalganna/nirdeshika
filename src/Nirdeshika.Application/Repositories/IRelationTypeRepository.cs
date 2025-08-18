using Nirdeshika.Domain.Entities;

namespace Nirdeshika.Application.Repositories;
public interface IRelationTypeRepository
{
    Task<IEnumerable<RelationType>> GetAllAsync();
    Task<RelationType?> GetByIdAsync(int id);
}
