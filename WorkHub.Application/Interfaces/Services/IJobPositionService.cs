using WorkHub.Application.DTOs.Creates;
using WorkHub.Application.DTOs.Updates;

namespace WorkHub.Application.Interfaces.Services;
public interface IJobPositionService
{
    Task<Guid> CreateAsync(CreateJobPositionDTO dto);
    Task<bool> UpdateAsync(UpdateJobPositionDTO dto);
    Task<bool> DeleteAsync(Guid id);
}