namespace WorkHub.Application.DTOs.Creates;
public class CreateEmployeeDTO
{
    public string FullName { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Guid JobPositionId { get; set; }
    public Guid CompanyId { get; set; }
}