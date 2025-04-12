using WorkHub.Domain.Entities.Base;

namespace WorkHub.Domain.Entities;
public class Company : BaseEntity
{
    public Company(string companyName, string email, string phoneNumber, string cnpj)
    {
        CompanyName = companyName;
        Email = email;
        PhoneNumber = phoneNumber;
        Cnpj = cnpj;
    }
    public void Update(string companyName, string email, string phoneNumber, string cnpj)
    {
        CompanyName = companyName;
        Email = email;
        PhoneNumber = phoneNumber;
        Cnpj = cnpj;
    }

    public string CompanyName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Cnpj {  get; set; } = string.Empty;
}