using FluentValidation;
using WorkHub.Application.DTOs.Creates;
using WorkHub.Application.DTOs.Updates;
using WorkHub.Application.Interfaces.Repositories;
using WorkHub.Application.Interfaces.Services;
using WorkHub.Domain.Entities;

namespace WorkHub.Application.Services;
public class EmployeeService(IEmployeeRepository _repository, 
    IValidator<CreateEmployeeDTO> _validator,
    IValidator<UpdateEmployeeDTO> _validatorUpdate
    ) : IEmployeeService
{
    public async Task<Guid> CreateAsync(CreateEmployeeDTO request)
    {
        var validation = await _validator.ValidateAsync(request);
        if (!validation.IsValid)
            throw new ValidationException(validation.Errors);

        var employee = new Employee(request.FullName, request.FirstName, request.Email, request.JobPositionId, request.CompanyId);
        await _repository.InsertAsync(employee);
        return employee.Id;
    }

    public async Task<bool> UpdateAsync(UpdateEmployeeDTO dto)
    {
        var validation = await _validatorUpdate.ValidateAsync(dto);
        if (!validation.IsValid)
            throw new ValidationException(validation.Errors);

        var existing = await _repository.GetByIdAsync(dto.Id);

        existing.Update(dto.FullName,dto.FirstName, dto.Email, dto.JobPositionId, dto.CompanyId);
        return await _repository.UpdateAsync(existing);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var employee = await _repository.GetByIdAsync(id);
        return await _repository.DeleteAsync(employee.Id);
    }
}
