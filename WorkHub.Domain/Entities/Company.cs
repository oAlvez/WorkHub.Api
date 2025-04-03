using WorkHub.Domain.Entities.Base;

namespace WorkHub.Domain.Entities;
public class Company : BaseEntity
{
    public string CompanyName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Cnpj {  get; set; } = string.Empty;
}