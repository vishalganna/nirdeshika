using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using MudBlazor;
using Nirdeshika.Application.DTOs;
using Nirdeshika.Application.Services;
using Nirdeshika.Web.Components.Dialogs;

namespace Nirdeshika.Web.Pages;

public partial class Family
{
    [Parameter]
    public int Id { get; set; }

    [Inject]
    public required IFamilyService FamilyService { get; set; }
    
    [Inject]
    public required IFamilyMemberService FamilyMemberService { get; set; }

    [Inject]
    public required IRelationTypeService RelationTypeService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        _family = await FamilyService.GetFamilyById(Id);
        _relationTypes = await RelationTypeService.GetAllRelationTypesAsync();
        await LoadFamilyMembersAsync();
        _isLoading = false;
    }

    private async Task OpenAddFamilyMemberDialogAsync()
    {
        var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true };

        var parameters = new DialogParameters
        {
            { nameof(AddFamilyMemberDialog.FamilyId), Id },
            { nameof(AddFamilyMemberDialog.RelationTypes), _relationTypes }
        };

        var dialog = await DialogService.ShowAsync<AddFamilyMemberDialog>("Add a family member", parameters, options);

        var result = await dialog.Result;

        if (!result!.Canceled && result.Data is int id)
        {
            await LoadFamilyMembersAsync();
        }
    }

    private async Task LoadFamilyMembersAsync()
    {
        _loadingFamilyMembers = true;
        _familyMembers = await FamilyMemberService.GetByFamilyIdAsync(Id);
        _loadingFamilyMembers = false;
    }

    private bool _isLoading;
    private bool _loadingFamilyMembers;
    private FamilyDto? _family;
    private IEnumerable<RelationTypeDto> _relationTypes = [];
    private IEnumerable<FamilyMemberDto>? _familyMembers = [];
}
