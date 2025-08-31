using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Nirdeshika.Application.DTOs;
using Nirdeshika.Application.Services;

namespace Nirdeshika.Web.Pages;

public partial class Users
{
    [Inject]
    public required IApplicationUserService ApplicationUserService { get; set; }
    [Inject]
    public required AuthenticationStateProvider AuthenticationStateProvider { get; set; }
    [Inject]
    public required IConfiguration Configuration { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        if (user.Identity?.IsAuthenticated ?? false)
        {
            // Try name first, fallback to email
            _user = user.FindFirst(c => c.Type.Contains("emailaddress"))?.Value;
        }

        await LoadUsersAsync();
        _isLoading = false;
    }

    private async Task OnApprovalChangedAsync(int id)
    {
        _isLoading = true;
        await ApplicationUserService.ToggleApprovalAsync(id);
        await LoadUsersAsync();
        _isLoading = false;
    }

    private async Task OnAdminStatusChangedAsync(ApplicationUserDto user)
    {
        var result = await DialogService.ShowMessageBox(
            "Warning",
            $"Are you sure want to update the admin status of {user.Email}?",
            yesText: "Yes", cancelText: "No");
        if (result.HasValue && result.Value)
        {
            _isLoading = true;
            await ApplicationUserService.ToggleAdminStatusAsync(user.Id);
            await LoadUsersAsync();
            _isLoading = false;
        }
    }

    private async Task LoadUsersAsync()
    {
        _users = await ApplicationUserService.GetAllAsync();
        var superUser = Configuration["SuperUser"] ?? string.Empty;
        if (_user is not null)
        {
            _users = _users.Where(u => u.Email != _user && u.Email != superUser);
        }
    }

    private bool _isLoading = true;
    private string? _user;
    private IEnumerable<ApplicationUserDto> _users = [];
}
