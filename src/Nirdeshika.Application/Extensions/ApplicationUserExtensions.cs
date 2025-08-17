using Nirdeshika.Application.DTOs;
using Nirdeshika.Domain.Entities;

namespace Nirdeshika.Application.Extensions;
public static class ApplicationUserExtensions
{
    public static ApplicationUserDto ToDto(this ApplicationUser source)
        => new(source.Id, source.Email, source.IsApproved);

    public static IEnumerable<ApplicationUserDto> ToDto(this IEnumerable<ApplicationUser> source)
        => source.Select(ToDto);
}
