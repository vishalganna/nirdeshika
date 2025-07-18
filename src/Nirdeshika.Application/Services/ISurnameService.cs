using Nirdeshika.Application.DTOs;

namespace Nirdeshika.Application.Services;
public interface ISurnameService
{
    Task<IEnumerable<SurnameDto>> GetAllSurnamesAsync();
}
