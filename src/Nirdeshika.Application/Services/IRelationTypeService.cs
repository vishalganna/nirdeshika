using Nirdeshika.Application.DTOs;

namespace Nirdeshika.Application.Services;
public interface IRelationTypeService
{
    Task<IEnumerable<RelationTypeDto>> GetAllRelationTypesAsync();
}
