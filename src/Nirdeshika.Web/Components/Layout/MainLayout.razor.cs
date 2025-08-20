using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Nirdeshika.Web.Components.Layout;

public partial class MainLayout
{
    [Inject]
    public required AuthenticationStateProvider AuthenticationStateProvider { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        _isAuthenticated = user.Identity?.IsAuthenticated ?? false;
        if (_isAuthenticated)
        {
            // Try name first, fallback to email
            _userName = user.Identity?.Name ?? user.FindFirst(c => c.Type == "name")?.Value;
            _avatarUrl = user.FindFirst(c => c.Type == "picture")?.Value ?? string.Empty;
        }
    }

    private void Logout()
    {
        NavigationManager.NavigateTo("/logout", true);
    }

    private void ToggleDrawer()
    {
        _open = !_open;
    }

    private readonly MudTheme _theme = new MudTheme()
    {
        Typography = new Typography()
        {
            Default = new DefaultTypography
            {
                FontFamily = ["Quicksand", "sans-serif"]
            },
            Body1 = new Body1Typography()
            {
                FontWeight = "500"
            },
            Body2 = new Body1Typography()
            {
                FontWeight = "500"
            }
        }
    };

    private bool _open = true;

    private string? _userName;
    private string _avatarUrl = string.Empty;
    private bool _isAuthenticated;
}
