using WorkHub.Application.DTOs.Creates;
using WorkHub.Application.DTOs.Updates;
using WorkHub.Domain.Entities;

namespace WorkHub.Application.Interfaces.Services;
public interface ICompanyService
{
    Task<Guid> CreateAsync(CreateCompanyDTO dto);
    Task<bool> DeleteAsync(Guid id);
    Task<IEnumerable<Company>> GetAllAsync();
    Task<Company> GetByIdAsync(Guid id);
    Task<bool> UpdateAsync(UpdateCompanyDTO dto);
}