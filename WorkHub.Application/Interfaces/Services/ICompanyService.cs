using WorkHub.Application.DTOs.Creates;
using WorkHub.Application.DTOs.Updates;

namespace WorkHub.Application.Interfaces.Services;
public interface ICompanyService
{
    Task<Guid> CreateAsync(CreateCompanyDTO dto);
    Task<bool> DeleteAsync(Guid id);
    Task<bool> UpdateAsync(UpdateCompanyDTO dto);
}