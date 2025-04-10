using WorkHub.Application.DTOs.Creates;

namespace WorkHub.Application.Interfaces.Services;
public interface IEmployeeService
{
    Task<Guid> CreateAsync(CreateEmployeeDTO dto);
}