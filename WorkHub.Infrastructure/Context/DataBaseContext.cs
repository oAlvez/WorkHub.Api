using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WorkHub.Domain.Entities;

namespace WorkHub.Infrastructure.Context
{
    public class DatabaseContext : IdentityDbContext<User,Role,Guid>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);      
        }
    }
}
