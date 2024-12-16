using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Movies.Domain.Repositories;
using Movies.Infrastructure.SQLite.Extensions;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSQLite();

using IHost host = builder.Build();

using var scope = host.Services.CreateScope();
var serviceProvider = scope.ServiceProvider;

var movieRepository = serviceProvider.GetRequiredService<IMovieRepository>();

var id = new Guid("823B3804-A82B-4F56-9A11-FE56BB8B1AD8");
var movie = await movieRepository.GetAsync(id, CancellationToken.None);
if (movie == null)
    Console.WriteLine($"Aucun film pour {id}");
else
    Console.WriteLine($"Id = {movie.Id}: {movie.Titre}");

//var movies = await movieRepository.GetAllAsync();
//var movie = movies.First();