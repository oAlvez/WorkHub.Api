using WorkHub.Application.DTOs.Updates;
using WorkHub.Domain.Entities;

namespace WorkHub.Application.Interfaces.Services;
public interface IUserService
{
    Task<Guid> CreateAsync(CreateUserDTO dto);
    Task<bool> UpdateAsync(UpdateUserDTO dto);
    Task<bool> DeleteAsync(Guid id);
}