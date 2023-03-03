using FilmsPhilippe.Application.UseCases.GetMovies;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        return services.AddScoped<IGetMoviesUseCase, GetMoviesUseCase>();
    }
}
