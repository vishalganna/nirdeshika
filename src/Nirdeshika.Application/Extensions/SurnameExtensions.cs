using Nirdeshika.Application.DTOs;
using Nirdeshika.Domain.Entities;

namespace Nirdeshika.Application.Extensions;
public static class SurnameExtensions
{
    public static SurnameDto ToDto(this Surname source)
        => new() { Id = source.Id, Name = source.Name};

    public static IEnumerable<SurnameDto> ToDto(this IEnumerable<Surname> source)
        => source.Select(ToDto);
}
