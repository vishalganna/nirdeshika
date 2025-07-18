using Nirdeshika.Domain.Entities;

namespace Nirdeshika.Application.Repositories;
public interface ISurnameRepository
{
    Task<IEnumerable<Surname>> GetAllAsync();
}
