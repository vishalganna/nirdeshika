namespace Nirdeshika.Application.DTOs;
public class FamilyDto
{
    public int Id { get; set; }
    public string Head { get; set; }
    public SurnameDto Surname { get; set; }
    public NativeDto Native { get; set; }
    public AddressDto Address { get; set; }
}
