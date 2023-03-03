using FilmsPhilippe.Application.Repositories;
using FilmsPhilippe.Infrastructure.MSAccess.Repositories;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection UseMsAccess(this IServiceCollection services)
    {
        return services.AddScoped<IMovieRepository, MovieRepository>();
    }
}
