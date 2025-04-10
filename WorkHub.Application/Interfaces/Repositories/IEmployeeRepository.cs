using WorkHub.Application.Interfaces.Repositories.Base;
using WorkHub.Domain.Entities;

namespace WorkHub.Application.Interfaces.Repositories;

public interface IEmployeeRepository : IBaseRepository<Employee>
{
    Task<bool> EmailExistsAsync(string email);
}