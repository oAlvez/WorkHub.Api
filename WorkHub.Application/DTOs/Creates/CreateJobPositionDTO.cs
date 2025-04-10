namespace WorkHub.Application.DTOs.Creates;
public class CreateJobPositionDTO
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double SalaryRange { get; set; } = 0;
    public Guid CompanyId { get; set; }
}