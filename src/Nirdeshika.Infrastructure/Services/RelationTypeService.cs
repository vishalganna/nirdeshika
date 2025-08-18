using Nirdeshika.Application.DTOs;
using Nirdeshika.Application.Extensions;
using Nirdeshika.Application.Repositories;
using Nirdeshika.Application.Services;

namespace Nirdeshika.Infrastructure.Services;
public class RelationTypeService(
    IRelationTypeRepository relationTypeRepository
    ) : IRelationTypeService
{
    public async Task<IEnumerable<RelationTypeDto>> GetAllRelationTypesAsync()
    {
        var relationTypes = await relationTypeRepository.GetAllAsync();
        return relationTypes.ToDto();
    }
}
