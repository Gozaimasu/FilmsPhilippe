using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Movies.Domain;
using Movies.Infrastructure.SQLite.Context;
using Movies.Infrastructure.SQLite.Repositories;

namespace Movies.Infrastructure.SQLite.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSQLite(this IServiceCollection services) =>
        services
            .AddDbContext<MoviesDbContext>((sp, b) =>
            {
                var configuration = sp.GetRequiredService<IConfiguration>();
                var sqLiteConnectionString = configuration.GetConnectionString("SQLite");
                b.UseSqlite(sqLiteConnectionString);
            })
            .AddScoped<IMovieRepository, MovieRepository>();
}
