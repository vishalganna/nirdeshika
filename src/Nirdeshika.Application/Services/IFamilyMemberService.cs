using Nirdeshika.Application.DTOs;

namespace Nirdeshika.Application.Services;
public interface IFamilyMemberService
{
    Task<IEnumerable<FamilyMemberDto>> GetByFamilyIdAsync(int familyId);
    Task<int?> AddFamilyMemberAsync(CreateFamilyMemberDto familyMemberDto);
}
