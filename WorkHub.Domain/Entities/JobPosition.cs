using WorkHub.Domain.Entities.Base;

namespace WorkHub.Domain.Entities;
public class JobPosition : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double SalaryRange { get; set; }
    public Guid CompanyId { get; set; }
}
