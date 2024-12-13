using FilmsPhilippe.Application.UseCases.GetActors;
using FilmsPhilippe.Application.UseCases.GetMovies;
using Microsoft.Extensions.DependencyInjection;

namespace FilmsPhilippe.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        return services
            .AddScoped<IGetMoviesUseCase, GetMoviesUseCase>()
            .AddScoped<IGetActorsUseCase, GetActorsUseCase>();
    }
}
