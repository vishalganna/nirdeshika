using System.ComponentModel.DataAnnotations;

namespace Nirdeshika.Web.ViewModels;

public class AddFamilyMemberViewModel
{
    [Required(ErrorMessage = "Please enter a name")]
    [StringLength(100, ErrorMessage = "Please enter a valid name")]
    public string Name { get; set; }

    public DateTime? DateOfBirth { get; set; } = DateTime.Now;
    [Required(ErrorMessage = "Please select a gender")]
    public char Gender { get; set; }
    public string? MobileNumber { get; set; }
    public byte RelationTypeId { get; set; }
    public string? Relative { get; set; }
    public bool IsFamilyHead { get; set; } = false;
}
