namespace Nirdeshika.Domain.Entities;
public class Family
{
    public int Id { get; set; }
    public required string Head { get; set; }
    public int SurnameId { get; set; }
    public int NativeId { get; set; }
    public int AddressId { get; set; }

    public Surname Surname { get; set; }
    public Native Native { get; set; }
    public Address Address { get; set; }
};
