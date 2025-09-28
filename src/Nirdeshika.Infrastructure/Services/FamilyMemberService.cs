using Nirdeshika.Application.DTOs;
using Nirdeshika.Application.Extensions;
using Nirdeshika.Application.Repositories;
using Nirdeshika.Application.Services;

namespace Nirdeshika.Infrastructure.Services;
public class FamilyMemberService(
    IFamilyMemberRepository familyMemberRepository
    ) : IFamilyMemberService
{
    public async Task<IEnumerable<FamilyMemberDto>> GetByFamilyIdAsync(int familyId)
    {
        var result = await familyMemberRepository.GetByFamilyIdAsync(familyId);
        return result.ToDto();
    }

    public async Task<int?> AddFamilyMemberAsync(CreateFamilyMemberDto familyMemberDto)
        => await familyMemberRepository.AddFamilyMemberAsync(familyMemberDto);

    public async Task<bool> DeleteAsync(int id)
        => await familyMemberRepository.DeleteAsync(id);

    public int UpdateFamilyMemberById(int id, CreateFamilyMemberDto familyMemberDto)
        => familyMemberRepository.UpdateFamilyMember(id, familyMemberDto);
}
