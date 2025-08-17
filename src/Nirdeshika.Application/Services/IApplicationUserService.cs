using Nirdeshika.Application.DTOs;

namespace Nirdeshika.Application.Services;
public interface IApplicationUserService
{
    Task<ApplicationUserDto?> GetByEmailAsync(string email);
    Task AddUserAsync(string email);
    Task<IEnumerable<ApplicationUserDto>> GetAllAsync();
    Task ToggleApprovalAsync(int id);
}
