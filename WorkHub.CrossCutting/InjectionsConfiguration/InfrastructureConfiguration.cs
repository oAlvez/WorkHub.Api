using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WorkHub.Application.Interfaces.Repositories;
using WorkHub.Domain.Entities;
using WorkHub.Infrastructure.Context;
using WorkHub.Infrastructure.Repositories;

namespace WorkHub.CrossCutting.InjectionsConfiguration;
public static class InfrastructureConfiguration
{
    public static IServiceCollection AddRepositoriesConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DatabaseContext>(options =>
        {
            options.UseSqlServer(configuration["ConnectionStrings:Connection"], sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 3,
                    maxRetryDelay: TimeSpan.FromSeconds(10),
                    errorNumbersToAdd: null
                );

            });
            options.EnableSensitiveDataLogging();
            options.LogTo(Console.WriteLine, LogLevel.Error);
        }, ServiceLifetime.Transient, ServiceLifetime.Transient);

        services.AddIdentity<User,IdentityRole<Guid>>().AddEntityFrameworkStores<DatabaseContext>().AddDefaultTokenProviders();
        
        services.AddScoped<ICompanyRepository, CompanyRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IJobPositionRepository, JobPositionRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}