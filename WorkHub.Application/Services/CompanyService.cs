using FluentValidation;
using WorkHub.Application.DTOs.Creates;
using WorkHub.Application.Interfaces.Repositories;
using WorkHub.Application.Interfaces.Services;
using WorkHub.Domain.Entities;

namespace WorkHub.Application.Services;
public class CompanyService(ICompanyRepository _repository, IValidator<CreateCompanyDTO> _validator) : ICompanyService
{
    public async Task<Guid> CreateAsync(CreateCompanyDTO request)
    {
        var validation = await _validator.ValidateAsync(request);
        if (!validation.IsValid)
            throw new ValidationException(validation.Errors);

        var company = new Company(request.CompanyName, request.Email, request.PhoneNumber, request.Cnpj);
        await _repository.InsertAsync(company);
        return company.Id;
    }
}
