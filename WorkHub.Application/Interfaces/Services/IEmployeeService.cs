using WorkHub.Application.DTOs.Creates;
using WorkHub.Application.DTOs.Updates;
using WorkHub.Domain.Entities;

namespace WorkHub.Application.Interfaces.Services;
public interface IEmployeeService
{
    Task<Guid> CreateAsync(CreateEmployeeDTO dto);
    Task<bool> DeleteAsync(Guid id);
    Task<IEnumerable<Employee>> GetAllAsync();
    Task<Employee> GetByIdAsync(Guid id);
    Task<bool> UpdateAsync(UpdateEmployeeDTO dto);
}