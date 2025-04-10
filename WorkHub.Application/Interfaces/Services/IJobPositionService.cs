using WorkHub.Application.DTOs.Creates;

namespace WorkHub.Application.Interfaces.Services;
public interface IJobPositionService
{
    Task<Guid> CreateAsync(CreateJobPositionDTO dto);
}