using FluentValidation;
using WorkHub.Application.DTOs.Creates;
using WorkHub.Application.DTOs.Updates;
using WorkHub.Application.Interfaces.Repositories;
using WorkHub.Application.Interfaces.Services;
using WorkHub.Domain.Entities;

namespace WorkHub.Application.Services;
public class JobPositionService(IJobPositionRepository _repository, 
    IValidator<CreateJobPositionDTO> _validator,
    IValidator<UpdateJobPositionDTO> _validatorUpdate
    ) : IJobPositionService
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

    public async Task<bool> UpdateAsync(UpdateJobPositionDTO dto)
    {
        var validation = await _validatorUpdate.ValidateAsync(dto);
        if (!validation.IsValid)
            throw new ValidationException(validation.Errors);

        var existing = await _repository.GetByIdAsync(dto.Id);

        existing.Update(dto.Title, dto.Description, dto.SalaryRange, dto.CompanyId);

        return await _repository.UpdateAsync(existing);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var jobPosition = await _repository.GetByIdAsync(id);
        return await _repository.DeleteAsync(jobPosition.Id);
    }
}
