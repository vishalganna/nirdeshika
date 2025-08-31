using Nirdeshika.Domain.Entities;

namespace Nirdeshika.Application.Repositories;
public interface IApplicationUserRepository
{
    Task<ApplicationUser?> GetByEmailAsync(string email);
    Task AddUserAsync(string email);
    Task<IEnumerable<ApplicationUser>> GetAllAsync();
    Task ToggleApprovalAsync(int id);
    Task ToggleAdminStatusAsync(int id);
}
