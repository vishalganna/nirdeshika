using Nirdeshika.Application.DTOs;
using Nirdeshika.Application.Extensions;
using Nirdeshika.Application.Repositories;
using Nirdeshika.Application.Services;

namespace Nirdeshika.Infrastructure.Services;
public class FamilyService(IFamilyRepository familyRepository) : IFamilyService
{
    public int? CreateFamily(UpsertFamilyDto family)
        => familyRepository.Create(family);

    public async Task<IEnumerable<FamilyDto>> GetAllFamiliesAsync()
    {
        var families = await familyRepository.GetAllAsync();
        return families.ToDto();
    }

    public async Task<FamilyDto?> GetFamilyById(int id)
    {
        var family = await familyRepository.GetByIdAsync(id);
        return family?.ToDto();
    }

    public int UpdateFamilyById(int id, UpsertFamilyDto family)
        => familyRepository.UpdateFamilyById(id, family);
}
