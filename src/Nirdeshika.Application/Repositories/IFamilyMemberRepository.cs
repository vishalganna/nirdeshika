using Nirdeshika.Application.DTOs;
using Nirdeshika.Domain.Entities;

namespace Nirdeshika.Application.Repositories;
public interface IFamilyMemberRepository
{
    Task<IEnumerable<FamilyMember>> GetByFamilyId(int familyId);
    Task<int?> AddFamilyMemberAsync(CreateFamilyMemberDto familyMemberDto);
    Task<bool> DeleteAsync(int id);
    int UpdateFamilyMember(int id, CreateFamilyMemberDto familyMember);
}
