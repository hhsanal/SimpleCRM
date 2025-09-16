using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class AppUser : IdentityUser<Guid>
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? FullName => string.Join(" ", Name, Surname);
}
