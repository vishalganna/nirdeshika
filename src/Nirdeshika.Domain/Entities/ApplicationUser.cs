namespace Nirdeshika.Domain.Entities;
public record ApplicationUser(int Id, string Email, bool IsApproved, bool? IsAdmin);