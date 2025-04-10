namespace WorkHub.Application.DTOs.Creates;
public class CreateCompanyDTO
{
    public string CompanyName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Cnpj { get; set; } = string.Empty;
}