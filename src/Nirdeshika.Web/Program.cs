using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using MudBlazor.Services;
using Nirdeshika.Application.Services;
using Nirdeshika.Infrastructure;
using Nirdeshika.Web.Components;
using Nirdeshika.Web.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddRazorComponents()
    .AddInteractiveServerComponents()
    ;

builder.Services.AddScoped<IAuthorizationHandler, ApprovedUserHandler>();

builder.Services.AddCascadingAuthenticationState();

builder.Services
    .AddInfrastructure()
    .AddMudServices()
    .AddApplicationInsightsTelemetry()
    .AddAuthorization(options =>
        {
            options.AddPolicy("ApprovedOnly", policy =>
                policy.Requirements.Add(new ApprovedUserRequirement()));
        })
    .AddAuthentication(options =>
        {
            options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
        })
    .AddCookie(options =>
    {
        options.LoginPath = "/signin-google";
        options.LogoutPath = "/logout";
    })
    .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
        {
            options.Authority = "https://accounts.google.com";
            options.ClientId = builder.Configuration["Authentication:Google:ClientId"];
            options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
            options.ClaimActions.MapJsonKey("urn:google:picture", "picture", "url");
            options.CallbackPath = "/signin-google";
            options.ResponseType = "code";
            options.Scope.Add("openid");
            options.Scope.Add("profile");
            options.Scope.Add("email");
            options.SaveTokens = true;

            // Capture user info on login
            options.Events = new OpenIdConnectEvents
            {
                OnTokenValidated = async ctx =>
                {
                    var applicationUserService = ctx.HttpContext.RequestServices.GetRequiredService<IApplicationUserService>();
                    var email = ctx.Principal?.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value;

                    if (!string.IsNullOrEmpty(email))
                    {
                        var user = await applicationUserService.GetByEmailAsync(email);
                        if (user is null)
                        {
                            await applicationUserService.AddUserAsync(email);
                        }
                    }
                }
            };
        })
    ;


var app = builder.Build();

app.MapGet("/login", async ctx =>
{
    var props = new AuthenticationProperties
    {
        RedirectUri = "/"
    };

    await ctx.ChallengeAsync(OpenIdConnectDefaults.AuthenticationScheme, props);
});

app.MapGet("/logout", async (HttpContext ctx) =>
{
    // Clear your app's auth cookie
    await ctx.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    return Results.Redirect("/");
});


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
