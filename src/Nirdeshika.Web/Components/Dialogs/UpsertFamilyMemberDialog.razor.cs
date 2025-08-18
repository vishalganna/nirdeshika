using Microsoft.AspNetCore.Components;
using MudBlazor;
using Nirdeshika.Application.DTOs;
using Nirdeshika.Application.Services;
using Nirdeshika.Web.ViewModels;

namespace Nirdeshika.Web.Components.Dialogs;

public partial class UpsertFamilyMemberDialog
{
    [Parameter]
    public FamilyMemberDto? FamilyMember { get; set; }

    [Parameter]
    public int FamilyId { get; set; }

    [Parameter]
    public required IEnumerable<RelationTypeDto> RelationTypes { get; set; }

    [CascadingParameter]
    public required IMudDialogInstance MudDialog { get; set; }

    [Inject]
    public required IFamilyMemberService FamilyMemberService { get; set; }


    protected override void OnInitialized()
    {
        if (FamilyMember is null)
        {
            return;
        }

        _model.Name = FamilyMember.Name;
        _model.DateOfBirth = FamilyMember.DateOfBirth;
        _model.Gender = FamilyMember.Gender;
        _model.MobileNumber = FamilyMember.MobileNumber;
        _model.RelationTypeId = FamilyMember.RelationTypeId ?? 0;
        _model.Relative = FamilyMember.Relative;
        _model.IsFamilyHead = FamilyMember.IsFamilyHead;
    }

    private async Task OnValidSubmitAsync()
    {
        _isWorking = true;
        var familyMember = new CreateFamilyMemberDto(
            _model.Name!,
            _model.DateOfBirth,
            _model.Gender,
            _model.MobileNumber,
            _model.RelationTypeId == 0 ? null : _model.RelationTypeId,
            _model.Relative,
            _model.IsFamilyHead,
            FamilyId);

        var result = IsUpdate
                        ? FamilyMemberService.UpdateFamilyMemberById(FamilyMember!.Id, familyMember)
                        : await FamilyMemberService.AddFamilyMemberAsync(familyMember)
                        ;

        if (result is not null)
        {
            Snackbar.Add(IsUpdate ? "Family member updated successfully." : "New family member added successfully.", Severity.Success);
        }
        else
        {
            Snackbar.Add($"Failed to {(IsUpdate ? "update" : "add")} family member, please try again.", Severity.Error);
        }

        MudDialog.Close(DialogResult.Ok(result));
        _isWorking = false;
    }

    private void Cancel() => MudDialog.Cancel();
    private bool IsUpdate => FamilyMember is not null;

    private readonly UpsertFamilyMemberViewModel _model = new();

    private bool _isWorking;
}
