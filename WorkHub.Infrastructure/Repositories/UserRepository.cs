using WorkHub.Application.Interfaces.Repositories;
using WorkHub.Infrastructure.Context;

namespace WorkHub.Infrastructure.Repositories;
public class UserRepository(DatabaseContext _context) : IUserRepository {  }