using Nirdeshika.Application.DTOs;

namespace Nirdeshika.Application.Services;
public interface IFamilyService
{
    int? CreateFamilyAsync(CreateFamilyDto family);
    Task<IEnumerable<FamilyDto>> GetAllFamiliesAsync();
    Task<FamilyDto?> GetFamilyById(int id);
}
