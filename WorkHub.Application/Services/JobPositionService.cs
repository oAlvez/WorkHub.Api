using FluentValidation;
using WorkHub.Application.DTOs.Creates;
using WorkHub.Application.Interfaces.Repositories;
using WorkHub.Application.Interfaces.Services;
using WorkHub.Domain.Entities;

namespace WorkHub.Application.Services;
public class JobPositionService(IJobPositionRepository _repository, IValidator<CreateJobPositionDTO> _validator) : IJobPositionService
{
    public async Task<Guid> CreateAsync(CreateJobPositionDTO request)
    {
        var validation = await _validator.ValidateAsync(request);
        if (!validation.IsValid)
            throw new ValidationException(validation.Errors);

        var jobPosition = new JobPosition(request.Title, request.Description, request.SalaryRange, request.CompanyId);
        await _repository.InsertAsync(jobPosition);
        return jobPosition.Id;
    }
}
