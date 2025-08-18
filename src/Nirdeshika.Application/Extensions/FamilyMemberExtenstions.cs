using Nirdeshika.Application.DTOs;
using Nirdeshika.Domain.Entities;

namespace Nirdeshika.Application.Extensions;
public static class FamilyMemberExtenstions
{
    public static FamilyMemberDto ToDto(this FamilyMember source)
        => new()
        {
            Id = source.Id,
            Name = source.Name,
            DateOfBirth =  source.DateOfBirth,
            Gender = source.Gender,
            MobileNumber = source.MobileNumber,
            RelationTypeId = source.RelationTypeId,
            Relative = source.Relative,
            IsFamilyHead = source.IsFamilyHead,
            Sequence = source.Sequence,
            FamilyId = source.FamilyId
        };

    public static IEnumerable<FamilyMemberDto> ToDto(this IEnumerable<FamilyMember> source)
        => source.Select(ToDto);
}
