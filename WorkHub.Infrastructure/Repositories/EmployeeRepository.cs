using Microsoft.EntityFrameworkCore;
using WorkHub.Application.Interfaces.Repositories;
using WorkHub.Domain.Entities;
using WorkHub.Infrastructure.Context;
using WorkHub.Infrastructure.Repositories.Base;

namespace WorkHub.Infrastructure.Repositories;
public class EmployeeRepository(DatabaseContext _context) : BaseRepository<Employee>(_context), IEmployeeRepository
{
    public async Task<bool> EmailExistsAsync(string email)
    {
        return await _context.Employees.AnyAsync(e => e.Email == email && !e.Deleted);
    }
}