using Nirdeshika.Domain.Entities;

namespace Nirdeshika.Application.Repositories;
public interface IAddressRepository
{
    Task<IEnumerable<Address>> GetAllAsync();
}
