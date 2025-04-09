using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using WorkHub.Domain.Entities;

namespace WorkHub.Infrastructure.Context;

public class DatabaseContext : IdentityDbContext<User, IdentityRole<Guid>,Guid>
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<JobPosition> JobPositions { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        var tableRenameMap = new Dictionary<string, string>
        {
            { "AspNetUsers", "Users" },
            { "AspNetRoles", "Roles" },
            { "AspNetUserRoles", "UserRoles" },
            { "AspNetUserClaims", "UserClaims" },
            { "AspNetRoleClaims", "RoleClaims" },
            { "AspNetUserLogins", "UserLogins" },
            { "AspNetUserTokens", "UserTokens" }
        };


        foreach (var entity in builder.Model.GetEntityTypes())
        {
            if (entity.GetTableName() is string currentName && tableRenameMap.TryGetValue(currentName, out var newName))
            {
                entity.SetTableName(newName);
            }
        }

        // Aplica todas as configurações
        builder.ApplyConfigurationsFromAssembly(typeof(DbContext).Assembly);

        // Força DeleteBehavior.Restrict em todas as FKs
        foreach (var foreignKey in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}
