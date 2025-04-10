using WorkHub.Domain.Entities.Base;

namespace WorkHub.Domain.Entities;
public class Employee : BaseEntity
{
    public Employee(string fullName, string firstName, string email, Guid jobPositionId, Guid companyId)
    {
        FullName = fullName;
        FirstName = firstName;
        Email = email;
        JobPositionId = jobPositionId;
        CompanyId = companyId;
    }

    public string FullName { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Guid JobPositionId { get; set; }
    public Guid CompanyId { get; set; }
    
    public virtual JobPosition JobPosition { get; set; } = null!;
    public virtual Company Company { get; set; } = null!;
}
