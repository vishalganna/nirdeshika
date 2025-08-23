using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Nirdeshika.Application.Repositories;

namespace Nirdeshika.Web.Handlers;

public class AdminUserRequirement : IAuthorizationRequirement;

public class AdminOnlyHandler(
    IApplicationUserRepository applicationUserRepository,
    IConfiguration configuration
    ) : AuthorizationHandler<AdminUserRequirement>
{

    protected override async Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        AdminUserRequirement requirement)
    {
        var email = context.User.FindFirst(ClaimTypes.Email)?.Value;

        if (email is not null)
        {
            var user = await applicationUserRepository.GetByEmailAsync(email);
            var superUser = configuration["SuperUser"] ?? string.Empty;
            if ((user?.IsAdmin != null && user.IsAdmin.Value) || superUser.Equals(user?.Email, StringComparison.CurrentCultureIgnoreCase))
            {
                context.Succeed(requirement);
            }
        }
    }
}
