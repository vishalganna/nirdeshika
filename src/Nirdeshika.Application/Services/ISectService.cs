using Nirdeshika.Application.DTOs;

namespace Nirdeshika.Application.Services;
public interface ISectService
{
    Task<IEnumerable<SectDto>> GetAllSectsAsync();
}
