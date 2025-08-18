using Microsoft.AspNetCore.Components;
using MudBlazor;
using Nirdeshika.Application.DTOs;
using Nirdeshika.Application.Services;
using Nirdeshika.Web.ViewModels;

namespace Nirdeshika.Web.Components.Dialogs;

public partial class UpsertFamilyDialog
{
    [Parameter]
    public FamilyDto? Family { get; set; }

    [Parameter]
    public required IEnumerable<SurnameDto> Surnames { get; set; }

    [Parameter]
    public required IEnumerable<NativeDto> Natives { get; set; }

    [Parameter]
    public required IEnumerable<SectDto> Sects { get; set; }

    [Parameter]
    public required IEnumerable<AddressDto> Addresses { get; set; }

    [CascadingParameter]
    public required IMudDialogInstance MudDialog { get; set; }

    [Inject]
    public required IFamilyService FamilyService { get; set; }

    protected override void OnInitialized()
    {
        if (Family is null)
        {
            return;
        }

        _model.Head = Family.Head;
        _model.SurnameId = Family.Surname!.Id;
        _model.NativeId = Family.Native!.Id;
        _model.SectId = Family.Sect!.Id;
        _model.AddressId = Family.Address!.Id;
    }

    private void OnValidSubmit()
    {
        _isWorking = true;
        var family = new UpsertFamilyDto(_model.Head!, _model.SurnameId, _model.NativeId, _model.SectId == 0 ? null : _model.SectId, _model.AddressId);

        var result = IsUpdate ? FamilyService.UpdateFamilyById(Family!.Id, family) : FamilyService.CreateFamily(family);

        if (result is not null)
        {
            Snackbar.Add(IsUpdate ? "Family updated successfully." : "New family added successfully.", Severity.Success);
        }
        else
        {
            Snackbar.Add($"Failed to {(IsUpdate ? "update" : "add new")} family, please try again.", Severity.Error);
        }

        MudDialog.Close(DialogResult.Ok(result));
        _isWorking = false;
    }

    private void Cancel() => MudDialog.Cancel();

    private bool IsUpdate => Family is not null;

    private readonly UpsertFamilyViewModel _model = new();

    private bool _isWorking;
}
