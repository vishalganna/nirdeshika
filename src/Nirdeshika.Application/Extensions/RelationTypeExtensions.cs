using Nirdeshika.Application.DTOs;
using Nirdeshika.Domain.Entities;

namespace Nirdeshika.Application.Extensions;
public static class RelationTypeExtensions
{
    public static RelationTypeDto ToDto(RelationType source)
        => new(source.Id, source.Type, source.Description);
    public static IEnumerable<RelationTypeDto> ToDto(this IEnumerable<Domain.Entities.RelationType> source)
        => source.Select(ToDto);
}
