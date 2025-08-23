using Microsoft.AspNetCore.Components;
using MudBlazor;
using Nirdeshika.Application.DTOs;
using Nirdeshika.Application.Services;
using Nirdeshika.Web.Components.Dialogs;

namespace Nirdeshika.Web.Pages;

public partial class Families
{
    [Inject]
    private ISurnameService SurnameService { get; set; } = default!;

    [Inject]
    private INativeService NativeService { get; set; } = default!;

    [Inject]
    private ISectService SectService { get; set; } = default!;

    [Inject]
    private IAddressService AddressService { get; set; } = default!;

    [Inject]
    private IFamilyService FamilyService { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        await Task.WhenAll(
            LoadSurnamesAsync(),
            LoadNativesAsync(),
            LoadAddressesAsync(),
            LoadSectsAsync(),
            LoadFamiliesAsync()
        );

        _isLoading = false;
    }
    private async Task OpenAddFamilyDialogAsync()
    {
        var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true };

        var parameters = new DialogParameters
        {
            { nameof(UpsertFamilyDialog.Surnames), _surnames },
            { nameof(UpsertFamilyDialog.Natives), _natives },
            { nameof(UpsertFamilyDialog.Sects), _sects },
            { nameof(UpsertFamilyDialog.Addresses), _addresses }
        };

        var dialog = await DialogService.ShowAsync<UpsertFamilyDialog>("Add a family", parameters, options);

        var result = await dialog.Result;

        if (!result!.Canceled && result.Data is int id)
        {
            NavigationManager.NavigateTo($"families/{id}");
        }
    }

    private async Task LoadSurnamesAsync()
    {
        _surnames = await SurnameService.GetAllSurnamesAsync();
    }

    private async Task LoadNativesAsync()
    {
        _natives = await NativeService.GetAllNativesAsync();
    }

    private async Task LoadAddressesAsync()
    {
        _addresses = await AddressService.GetAllAddressesAsync();
    }

    private async Task LoadSectsAsync()
    {
        _sects = await SectService.GetAllSectsAsync();
    }

    private async Task LoadFamiliesAsync()
    {
        _families = await FamilyService.GetAllFamiliesAsync();
    }

    private void GoToFamily(int id)
        => NavigationManager.NavigateTo($"/families/{id}");

    private async Task UpdateFamilyAsync(FamilyDto family)
    {
        var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true };

        var parameters = new DialogParameters
        {
            { nameof(UpsertFamilyDialog.Family), family },
            { nameof(UpsertFamilyDialog.Surnames), _surnames },
            { nameof(UpsertFamilyDialog.Natives), _natives },
            { nameof(UpsertFamilyDialog.Sects), _sects },
            { nameof(UpsertFamilyDialog.Addresses), _addresses }
        };

        var dialog = await DialogService.ShowAsync<UpsertFamilyDialog>("Update family", parameters, options);
        var result = await dialog.Result;
        if (!result!.Canceled && result.Data is int)
        {
            _isLoading = true;
            _families = await FamilyService.GetAllFamiliesAsync();
            _isLoading = false;
        }
    }

    private bool _isLoading = true;
    private IEnumerable<SurnameDto> _surnames = [];
    private IEnumerable<NativeDto> _natives = [];
    private IEnumerable<AddressDto> _addresses = [];
    private IEnumerable<SectDto> _sects = [];
    private IEnumerable<FamilyDto> _families = [];
}
