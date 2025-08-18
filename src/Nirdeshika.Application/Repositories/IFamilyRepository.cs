using Nirdeshika.Application.DTOs;
using Nirdeshika.Domain.Entities;

namespace Nirdeshika.Application.Repositories;
public interface IFamilyRepository
{
    int? Create(UpsertFamilyDto family);
    Task<IEnumerable<Family>> GetAllAsync();
    Task<Family?> GetByIdAsync(int id);
    int UpdateFamilyById(int id, UpsertFamilyDto family);
}
