using Nirdeshika.Application.DTOs;
using Nirdeshika.Domain.Entities;

namespace Nirdeshika.Application.Extensions;
public static class SectExtensions
{
    public static SectDto ToDto(this Sect source)
        => new() { Id = source.Id, Name = source.Name};

    public static IEnumerable<SectDto> ToDto(this IEnumerable<Sect> source)
        => source.Select(ToDto);
}
