using Nirdeshika.Application.DTOs;
using Nirdeshika.Application.Extensions;
using Nirdeshika.Application.Repositories;
using Nirdeshika.Application.Services;

namespace Nirdeshika.Infrastructure.Services;
public class ApplicationUserService(IApplicationUserRepository applicationUserRepository) : IApplicationUserService
{
    public async Task<ApplicationUserDto?> GetByEmailAsync(string email)
    {
        var user = await applicationUserRepository.GetByEmailAsync(email);
        return user?.ToDto();
    }

    public async Task AddUserAsync(string email)
        => await applicationUserRepository.AddUserAsync(email);

    public async Task<IEnumerable<ApplicationUserDto>> GetAllAsync()
    {
        var users = await applicationUserRepository.GetAllAsync();
        return users.ToDto();
    }

    public async Task ToggleApprovalAsync(int id)
        => await applicationUserRepository.ToggleApprovalAsync(id);

    public async Task ToggleAdminStatusAsync(int id)
        => await applicationUserRepository.ToggleAdminStatusAsync(id);
}
