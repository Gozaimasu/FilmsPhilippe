using ConsoleApp2.Domain.Repositories;
using ConsoleApp2.Infrastructure.SQLite.Context;
using ConsoleApp2.Infrastructure.SQLite.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp2.Infrastructure.SQLite.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSqLite(this IServiceCollection services) =>
        services
            .AddDbContext<MoviesDbContext>((sp, b) =>
            {
                var configuration = sp.GetRequiredService<IConfiguration>();
                var sqLiteConnectionString = configuration.GetConnectionString("SQLite");
                b.UseSqlite(sqLiteConnectionString);
            })
            .AddKeyedScoped<IMovieRepository, MovieRepository>("SQLite");
}