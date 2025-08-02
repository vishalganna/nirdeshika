using Nirdeshika.Application.DTOs;
using Nirdeshika.Application.Extensions;
using Nirdeshika.Application.Repositories;
using Nirdeshika.Application.Services;

namespace Nirdeshika.Infrastructure.Services;
public class SectService(
    ISectRepository sectRepository
    ) : ISectService
{
    public async Task<IEnumerable<SectDto>> GetAllSectsAsync()
    {
        var sects = await sectRepository.GetAllAsync();
        return sects.ToDto();
    }
}
