using WorkHub.Domain.Entities.Base;

namespace WorkHub.Domain.Entities;
public class JobPosition : BaseEntity
{
    public JobPosition(string title, string description, double salaryRange, Guid companyId)
    {
        Title = title;
        Description = description;
        SalaryRange = salaryRange;
        CompanyId = companyId;
    }
    public void Update(string title, string description, double salaryRange, Guid companyId)
    {
        Title = title;
        Description = description;
        SalaryRange = salaryRange;
        CompanyId = companyId;        
    }

    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double SalaryRange { get; set; }
    
    public Guid CompanyId { get; set; }
    public virtual Company Company { get; set; } = null!;
}
