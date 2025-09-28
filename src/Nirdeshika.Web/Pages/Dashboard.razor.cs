using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Nirdeshika.Web.Services;

namespace Nirdeshika.Web.Pages;

public partial class Dashboard
{
    [Inject]
    public QuestPdfService PdfService { get; set; } = null!;
    [Inject]
    public IJSRuntime JsRuntime { get; set; } = null!;

    private async Task GeneratePdf()
    {
        _processing = true;
        var pdfBytes = await PdfService.CreateFamilyDataPdfAsync(
            new Tuple<bool, int, int>(_includeMales, _maleMinAge, _maleMaxAge),
            new Tuple<bool, int, int>(_includeFemales, _femaleMinAge, _femaleMaxAge));
        var base64 = Convert.ToBase64String(pdfBytes);

        await JsRuntime.InvokeVoidAsync("downloadFile", "FamilyData.pdf", base64);
        _processing = false;
    }
    private readonly List<int> _ageRange = Enumerable.Range(15, 90).ToList();

    private bool _includeMales = true;
    private int _maleMinAge = 18;
    private int _maleMaxAge = 40;
    private bool _includeFemales = true;
    private int _femaleMinAge = 18;
    private int _femaleMaxAge = 40;

    private bool _processing = false;
}
