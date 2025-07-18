using Nirdeshika.Application.DTOs;
using Nirdeshika.Domain.Entities;

namespace Nirdeshika.Application.Extensions;
public static class SurnameExtensions
{
    public static SurnameDto ToDto(this Surname source)
        => new SurnameDto(source.Id, source.Name);

    public static IEnumerable<SurnameDto> ToDto(this IEnumerable<Surname> source)
        => source.Select(ToDto);
}
