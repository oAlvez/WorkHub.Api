using Microsoft.AspNetCore.Identity;

namespace WorkHub.Domain.Entities;
public class User : IdentityUser<Guid>
{
    public string FullName { get; set; } = string.Empty;
    public string ShortName { get; set; } = string.Empty;
}
