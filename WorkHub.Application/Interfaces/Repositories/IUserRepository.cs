using WorkHub.Domain.Entities;

namespace WorkHub.Application.Interfaces.Repositories;
public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllAsync();
}