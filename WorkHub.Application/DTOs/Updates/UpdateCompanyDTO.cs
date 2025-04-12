namespace WorkHub.Application.DTOs.Updates;
public class UpdateCompanyDTO
{
    public Guid Id { get; set; }
    public string CompanyName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Cnpj { get; set; } = string.Empty;
}