using Nirdeshika.Application.DTOs;
using Nirdeshika.Domain.Entities;

namespace Nirdeshika.Application.Extensions;
public static class NativeExtensions
{
    public static NativeDto ToDto(this Native source)
        => new() { Id = source.Id, Name = source.Name};

    public static IEnumerable<NativeDto> ToDto(this IEnumerable<Native> source)
        => source.Select(ToDto);
}
