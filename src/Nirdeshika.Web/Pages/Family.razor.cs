using Microsoft.AspNetCore.Components;
using Nirdeshika.Application.DTOs;
using Nirdeshika.Application.Services;

namespace Nirdeshika.Web.Pages;

public partial class Family
{
    [Parameter]
    public int Id { get; set; }

    [Inject]
    public required IFamilyService FamilyService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        _family = await FamilyService.GetFamilyById(Id);
        _isLoading = false;
    }

    private bool _isLoading;
    private FamilyDto? _family;
}
