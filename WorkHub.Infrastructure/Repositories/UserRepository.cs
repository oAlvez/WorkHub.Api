using Microsoft.EntityFrameworkCore;
using WorkHub.Application.Interfaces.Repositories;
using WorkHub.Domain.Entities;
using WorkHub.Infrastructure.Context;

namespace WorkHub.Infrastructure.Repositories;
public class UserRepository(DatabaseContext _context) : IUserRepository 
{
    public async Task<IEnumerable<User>> GetAllAsync() => await _context.Users.AsNoTracking().ToListAsync();
}