using System.ComponentModel.DataAnnotations;

namespace Nirdeshika.Web.ViewModels;

public class AddFamilyViewModel
{
    [Required(ErrorMessage = "Please enter family head name.")]
    [StringLength(100, ErrorMessage = "Please enter a valid name.")]
    public string? Head { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Please select a surname.")]
    public int SurnameId { get; set; } = 0;
    [Range(1, int.MaxValue, ErrorMessage = "Please select a native.")]
    public int NativeId { get; set; } = 0;

    public int SectId { get; set; } = 0;
    [Range(1, int.MaxValue, ErrorMessage = "Please select a area.")]
    public int AddressId { get; set; } = 0;
}
