using Nirdeshika.Application.DTOs;
using Nirdeshika.Domain.Entities;

namespace Nirdeshika.Application.Extensions;
public static class AddressExtensions
{
    public static AddressDto ToDto(this Address source)
        => new() { Id = source.Id, Area = source.Area };

    public static IEnumerable<AddressDto> ToDto(this IEnumerable<Address> source)
        => source.Select(ToDto);
}
