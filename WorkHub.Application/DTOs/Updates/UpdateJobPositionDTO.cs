namespace WorkHub.Application.DTOs.Updates;
public class UpdateJobPositionDTO
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double SalaryRange { get; set; } = 0;
    public Guid CompanyId { get; set; }
}