using FluentValidation;
using WorkHub.Application.DTOs.Creates;
using WorkHub.Application.DTOs.Updates;
using WorkHub.Application.Interfaces.Repositories;
using WorkHub.Application.Interfaces.Services;
using WorkHub.Domain.Entities;

namespace WorkHub.Application.Services;
public class CompanyService(ICompanyRepository _repository, IValidator<CreateCompanyDTO> _validator, IValidator<UpdateCompanyDTO> _validatorUpdate) : ICompanyService
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

    public async Task<bool> UpdateAsync(UpdateCompanyDTO dto)
    {
        var validation = await _validatorUpdate.ValidateAsync(dto);
        if (!validation.IsValid)
            throw new ValidationException(validation.Errors);

        var existingCompany = await _repository.GetByIdAsync(dto.Id);

        existingCompany.Update(dto.CompanyName, dto.Email, dto.PhoneNumber, dto.Cnpj);

        return await _repository.UpdateAsync(existingCompany);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var company = await _repository.GetByIdAsync(id);
        return await _repository.DeleteAsync(company.Id);
    }
}
