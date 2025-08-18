using Nirdeshika.Domain.Entities;

namespace Nirdeshika.Application.Repositories;
public interface INativeRepository
{
    Task<IEnumerable<Native>> GetAllAsync();
}
