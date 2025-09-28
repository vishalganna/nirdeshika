using Nirdeshika.Application.DTOs;

namespace Nirdeshika.Web.Export;

public class FamilyExportModel(FamilyDto family, IEnumerable<FamilyMemberDto> familyMembers)
{
    public FamilyDto Family { get; } = family;
    public IEnumerable<FamilyMemberDto> FamilyMembers { get; } = familyMembers;
}
