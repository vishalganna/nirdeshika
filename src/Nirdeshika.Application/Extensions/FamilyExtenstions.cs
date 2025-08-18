using Nirdeshika.Application.DTOs;
using Nirdeshika.Domain.Entities;

namespace Nirdeshika.Application.Extensions;
public static class FamilyExtenstions
{
    public static FamilyDto ToDto(this Family source)
        => new()
        {
            Id = source.Id,
            Head = source.Head,
            Surname = source.Surname?.ToDto(),
            Sect = source.Sect?.ToDto(),
            Native = source.Native?.ToDto(),
            Address = source.Address?.ToDto()
        };

    public static IEnumerable<FamilyDto> ToDto(this IEnumerable<Family> source)
        => source.Select(ToDto);
}
