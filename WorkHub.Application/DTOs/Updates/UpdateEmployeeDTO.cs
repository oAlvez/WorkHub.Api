namespace WorkHub.Application.DTOs.Updates;
public class UpdateEmployeeDTO
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Guid JobPositionId { get; set; }
    public Guid CompanyId { get; set; }
}