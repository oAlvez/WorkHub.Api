using WorkHub.Domain.Entities.Base;

namespace WorkHub.Domain.Entities;
public class Claim : BaseEntity
{
    public Guid RoleId { get; set; }
    public string Group { get; set; } = string.Empty;
    public string Name { get; set;} = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Value { get; set;} = string.Empty;
}