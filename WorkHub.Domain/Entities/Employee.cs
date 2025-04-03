using WorkHub.Domain.Entities.Base;

namespace WorkHub.Domain.Entities;
public class Employee : BaseEntity
{
    public string FullName { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Guid JobPositionId { get; set; }
    public Guid CompanyId { get; set; }
}
