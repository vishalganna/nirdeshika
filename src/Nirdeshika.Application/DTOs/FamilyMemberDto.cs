namespace Nirdeshika.Application.DTOs;
public class FamilyMemberDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public char Gender { get; set; }
    public string? MobileNumber { get; set; }
    public byte? RelationTypeId { get; set; }
    public string? Relative { get; set; }
    public bool IsFamilyHead { get; set; }
    public byte Sequence { get; set; }
    public int FamilyId { get; set; }
}
