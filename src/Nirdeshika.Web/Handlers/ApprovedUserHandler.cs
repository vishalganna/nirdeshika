using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Nirdeshika.Application.Repositories;

namespace Nirdeshika.Web.Handlers;

public class ApprovedUserRequirement : IAuthorizationRequirement;

public class ApprovedUserHandler(
    IApplicationUserRepository applicationUserRepository,
    IConfiguration configuration
    ) : AuthorizationHandler<ApprovedUserRequirement>
{

    protected override async Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        ApprovedUserRequirement requirement)
    {
        var email = context.User.FindFirst(ClaimTypes.Email)?.Value;

        if (email is not null)
        {
            var user = await applicationUserRepository.GetByEmailAsync(email);
            var superUser = configuration["SuperUser"] ?? string.Empty;
            if ((user is not null && user.IsApproved) || superUser.Equals(user?.Email, StringComparison.CurrentCultureIgnoreCase))
            {
                context.Succeed(requirement);
            }
        }
    }
}
