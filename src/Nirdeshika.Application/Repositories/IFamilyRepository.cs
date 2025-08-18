using Nirdeshika.Application.DTOs;
using Nirdeshika.Domain.Entities;

namespace Nirdeshika.Application.Repositories;
public interface IFamilyRepository
{
    int? Create(CreateFamilyDto family);
    Task<IEnumerable<Family>> GetAllAsync();
    Task<Family?> GetByIdAsync(int id);
}
