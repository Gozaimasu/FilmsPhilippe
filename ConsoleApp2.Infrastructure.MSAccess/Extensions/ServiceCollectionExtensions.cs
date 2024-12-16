using ConsoleApp2.Domain.Repositories;
using ConsoleApp2.Infrastructure.MSAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp2.Infrastructure.MSAccess.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMsAccess(this IServiceCollection services)
    {
        return services.AddKeyedScoped<IMovieRepository, MovieRepository>("MsAccess");
    }
}