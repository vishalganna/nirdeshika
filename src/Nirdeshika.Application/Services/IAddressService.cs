using Nirdeshika.Application.DTOs;

namespace Nirdeshika.Application.Services;
public interface IAddressService
{
    Task<IEnumerable<AddressDto>> GetAllAddressesAsync();
}
