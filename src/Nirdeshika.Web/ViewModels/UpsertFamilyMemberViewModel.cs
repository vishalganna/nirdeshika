using System.ComponentModel.DataAnnotations;

namespace Nirdeshika.Web.ViewModels;

public class UpsertFamilyMemberViewModel
{
    [Required(ErrorMessage = "Please enter a name")]
    [StringLength(100, ErrorMessage = "Please enter a valid name")]
    public string? Name { get; set; }
    public DateTime? DateOfBirth { get; set; } = DateTime.Now;
    public char Gender { get; set; } = 'M';
    [RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Enter a valid 10-digit mobile number.")]
    public string? MobileNumber { get; set; }
    public byte RelationTypeId { get; set; } = 0;
    public string? Relative { get; set; }
    public bool IsFamilyHead { get; set; } = false;
}
