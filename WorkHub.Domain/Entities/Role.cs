using Microsoft.AspNetCore.Identity;

namespace WorkHub.Domain.Entities;
public class Role : IdentityRole<Guid>
{
    public virtual ICollection<Claim>? Claims { get; set; }
}
