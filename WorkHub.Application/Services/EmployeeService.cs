using FluentValidation;
using WorkHub.Application.DTOs.Creates;
using WorkHub.Application.Interfaces.Repositories;
using WorkHub.Application.Interfaces.Services;
using WorkHub.Domain.Entities;

namespace WorkHub.Application.Services;
public class EmployeeService(IEmployeeRepository _repository, IValidator<CreateEmployeeDTO> _validator) : IEmployeeService
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
}
