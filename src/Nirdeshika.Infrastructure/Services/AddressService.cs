using Nirdeshika.Application.DTOs;
using Nirdeshika.Application.Extensions;
using Nirdeshika.Application.Repositories;
using Nirdeshika.Application.Services;

namespace Nirdeshika.Infrastructure.Services;
public class AddressService(IAddressRepository addressRepository) : IAddressService
{
    public async Task<IEnumerable<AddressDto>> GetAllAddressesAsync()
    {
        var addresses = await addressRepository.GetAllAsync();
        return addresses.ToDto();
    }
}
