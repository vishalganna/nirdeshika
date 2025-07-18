using Nirdeshika.Application.DTOs;
using Nirdeshika.Application.Extensions;
using Nirdeshika.Application.Repositories;
using Nirdeshika.Application.Services;

namespace Nirdeshika.Infrastructure.Services;
public class SurnameService(ISurnameRepository surnameRepository) : ISurnameService
{
    public async Task<IEnumerable<SurnameDto>> GetAllSurnamesAsync()
    {
        var surnames = await surnameRepository.GetAllAsync();
        return surnames.ToDto();
    }
}
