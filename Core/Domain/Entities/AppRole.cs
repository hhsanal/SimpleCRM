using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class AppRole : IdentityRole<Guid>
{
    public int? ParentId { get; set; }
    public int RoleCode { get; set; }
    public string? ModuleName { get; set; }
    public string? Description { get; set; }
    public int? Order { get; set; }
}
