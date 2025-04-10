using WorkHub.Application.DTOs.Creates;

namespace WorkHub.Application.Interfaces.Services;
public interface ICompanyService
{
    Task<Guid> CreateAsync(CreateCompanyDTO dto);
}