using Nirdeshika.Application.DTOs;

namespace Nirdeshika.Application.Services;
public interface IFamilyService
{
    int? CreateFamily(UpsertFamilyDto family);
    Task<IEnumerable<FamilyDto>> GetAllFamiliesAsync();
    Task<FamilyDto?> GetFamilyById(int id);
    int UpdateFamilyById(int id, UpsertFamilyDto family);

}
