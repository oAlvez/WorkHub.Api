using WorkHub.Infrastructure.Persistence.Seeds;

namespace WorkHub.CrossCutting.Extensions;
public static class ServiceProviderExtensions
{
    public static async Task RunSeedersAsync(this IServiceProvider serviceProvider)
    {
        await IdentitySeeder.SeedAsync(serviceProvider);
    }
}