using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WorkHub.CrossCutting.InjectionsConfiguration;
public static class OptionsConfiguration
{
    public static IServiceCollection AddOptionsConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}