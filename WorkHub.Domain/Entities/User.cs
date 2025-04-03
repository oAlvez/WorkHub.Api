using Microsoft.AspNetCore.Identity;

namespace WorkHub.Domain.Entities;
public class User : IdentityUser<Guid>
{
    public string FullName { get; set; } = string.Empty;
    public string ShortName { get; set; } = string.Empty;
    public DateTime CreateAt { get; set; } = DateTime.Now;
    public DateTime UpdateAt { get; set; }
    public Guid CreateUserId { get; set; }
    public Guid UpdateUserId { get; set; }
}
