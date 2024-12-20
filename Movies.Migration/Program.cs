using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Movies.Domain.Repositories;
using Movies.Infrastructure.SQLite.Extensions;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSQLite();

using var host = builder.Build();

using var scope = host.Services.CreateScope();
var serviceProvider = scope.ServiceProvider;

serviceProvider.GetRequiredService<IMovieRepository>();

//var movies = await movieRepository.GetAllAsync();
//var movie = movies.First();