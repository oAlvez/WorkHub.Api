using WorkHub.Application.DTOs.Creates;
using WorkHub.Application.DTOs.Updates;

namespace WorkHub.Application.Interfaces.Services;
public interface IEmployeeService
{
    Task<Guid> CreateAsync(CreateEmployeeDTO dto);
    Task<bool> DeleteAsync(Guid id);
    Task<bool> UpdateAsync(UpdateEmployeeDTO dto);
}