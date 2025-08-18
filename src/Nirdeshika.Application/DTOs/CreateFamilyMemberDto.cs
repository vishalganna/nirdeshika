namespace Nirdeshika.Application.DTOs;
public record CreateFamilyMemberDto(
    string Name,
    DateTime? DateOfBirth,
    char Gender,
    string? MobileNumber,
    byte? RelationTypeId,
    string? Relative,
    bool IsFamilyHead,
    int FamilyId
    );