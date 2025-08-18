using Nirdeshika.Application.DTOs;
using Nirdeshika.Application.Extensions;
using Nirdeshika.Application.Repositories;
using Nirdeshika.Application.Services;

namespace Nirdeshika.Infrastructure.Services;
public class NativeService(INativeRepository nativeRepository) : INativeService
{
    public async Task<IEnumerable<NativeDto>> GetAllNativesAsync()
    {
        var natives = await nativeRepository.GetAllAsync();
        return natives.ToDto();
    }
}
