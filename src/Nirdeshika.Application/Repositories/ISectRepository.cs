using Nirdeshika.Domain.Entities;

namespace Nirdeshika.Application.Repositories;
public interface ISectRepository
{
    Task<IEnumerable<Sect>> GetAllAsync();
}
