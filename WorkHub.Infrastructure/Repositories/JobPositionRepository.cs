using WorkHub.Application.Interfaces.Repositories;
using WorkHub.Domain.Entities;
using WorkHub.Infrastructure.Context;
using WorkHub.Infrastructure.Repositories.Base;

namespace WorkHub.Infrastructure.Repositories;
public class JobPositionRepository(DatabaseContext _context) : BaseRepository<JobPosition>(_context), IJobPositionRepository
{
}