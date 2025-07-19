using Nirdeshika.Application.DTOs;

namespace Nirdeshika.Application.Services;
public interface INativeService
{
    Task<IEnumerable<NativeDto>> GetAllNativesAsync();
}
