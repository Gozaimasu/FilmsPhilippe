using System.Diagnostics;
using ConsoleApp2.Domain.Repositories;
using ConsoleApp2.Infrastructure.MSAccess.Extensions;
using ConsoleApp2.Infrastructure.SQLite.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// Création du builder
var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddMsAccess()
    .AddSqLite();

// Création du host
using var host = builder.Build();

// Création d'un scope et récupération du service provider
using var scope = host.Services.CreateScope();
var serviceProvider = scope.ServiceProvider;

var msAccessRepository = serviceProvider.GetRequiredKeyedService<IMovieRepository>("MsAccess");
var movies =  msAccessRepository
    .GetAllAsync(CancellationToken.None)
    .ToBlockingEnumerable()
    .ToList();

Console.WriteLine($"Il y a {movies.Count:n0} films");
Console.WriteLine();

var actors = movies
    .SelectMany(m => m.Actors)
    .ToList();
Console.WriteLine($"Il y a {actors.Count:n0} acteurs");
Console.WriteLine($"Il y a {actors.Distinct().Count():n0} acteurs différents");
Console.WriteLine();

var directors = movies
    .SelectMany(m => m.Directors)
    .ToList();
Console.WriteLine($"Il y a {directors.Count:n0} réalisateurs");
Console.WriteLine($"Il y a {directors.Distinct().Count():n0} réalisateurs différents");

var sqliteMovieRepository = serviceProvider.GetRequiredKeyedService<IMovieRepository>("SQLite");
var start = Stopwatch.GetTimestamp();
Console.WriteLine("Ajout des films dans SQLite");
sqliteMovieRepository.AddRangeAsync(movies).Wait();
var elapsed = Stopwatch.GetElapsedTime(start);

Console.WriteLine($"{movies.Count:n0} movies added in {elapsed}");