using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class AppUser : IdentityUser<Guid>
{
    public string? SmallName { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? FullName => string.Join(" ", Name, Surname);
    public string? PassCreationCode { get; set; }
    public int ExtraEntryCount { get; set; }
    public int? TwoFactorMethod { get; set; }
    public DateTime LicenceEndDate { get; set; }
    public int MailAccountId { get; set; }
}
