using WorkHub.Application.Interfaces.Repositories;
using WorkHub.Domain.Entities;
using WorkHub.Infrastructure.Context;
using WorkHub.Infrastructure.Repositories.Base;

namespace WorkHub.Infrastructure.Repositories;
public class CompanyRepository(DatabaseContext _context) : BaseRepository<Company>(_context), ICompanyRepository
{
}