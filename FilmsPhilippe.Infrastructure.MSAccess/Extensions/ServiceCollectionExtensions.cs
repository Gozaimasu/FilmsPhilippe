using FilmsPhilippe.Application.Repositories;
using FilmsPhilippe.Infrastructure.MSAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FilmsPhilippe.Infrastructure.MSAccess.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection UseMsAccess(this IServiceCollection services)
    {
        return services
            .AddScoped<IMovieRepository, MovieRepository>()
            .AddScoped<IActorRepository, ActorRepository>();
    }
}
