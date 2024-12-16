using ConsoleApp2;
using System.Data.Common;
using System.Data.Odbc;
using ConsoleApp2.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using static ConsoleApp2.Domain.Processes.AddActorDefaults;
using static ConsoleApp2.Domain.Processes.AddAssistantDirectorDefaults;
using static ConsoleApp2.Domain.Processes.AddDialogWriterDefaults;
using static ConsoleApp2.Domain.Processes.AddDirectorDefaults;
using static ConsoleApp2.Domain.Processes.AddEditingDefaults;
using static ConsoleApp2.Domain.Processes.AddMusicDefaults;
using static ConsoleApp2.Domain.Processes.AddOriginalWriterDefaults;
using static ConsoleApp2.Domain.Processes.AddPhotographerDefaults;
using static ConsoleApp2.Domain.Processes.AddScriptwriterDefaults;

// Création du builder
var builder = Host.CreateApplicationBuilder(args);

// Création du host
using var host = builder.Build();

// Création d'un scope et récupération du service provider
using var scope = host.Services.CreateScope();
var serviceProvider = scope.ServiceProvider;

var configuration = serviceProvider.GetRequiredService<IConfiguration>();
var msAccessConnectionString = configuration.GetConnectionString("MSAccess");
if (string.IsNullOrEmpty(msAccessConnectionString))
    throw new ApplicationException("MSAccess connection string is missing.");

var movies = GetMovies(msAccessConnectionString).ToList();

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

return;

static IEnumerable<MovieType> GetMovies(string connectionString)
{
    OdbcCommand command = new("SELECT TITRE, ANNEE, ORIGINE, MINUTAGE, TITRE_OR, REALISAT_1, REALISAT_2, ACTEUR_1, ACTEUR_2, ACTEUR_3, ACTEUR_4, ACTEUR_5, ACTEUR_6, ACTEUR_7, ACTEUR_8, ACTEUR_9, ACTEUR_10, ACTEUR_11, ACTEUR_12, ACTEUR_13, ACTEUR_14, ACTEUR_15, ACTEUR_16, SCENARIO, SCENARIO1, ASS_REAL_1, ASS_REAL_2, ASS_REAL_3, D_APRES, DIALOGUE, PHOTO, MONTAGE, MUSIQUE FROM FILM");
    const int nbDirectors = 2;
    const int nbActors = 16;
    const int nbScriptwriters = 2;
    const int nbAssistantDirectors = 3;

    using OdbcConnection connection = new(connectionString);
    command.Connection = connection;
    connection.Open();

    var reader = command.ExecuteReader();

    while (reader.Read())
    {
        var offset = 0;
        var title = Title.Create(reader.GetString(offset++));
        if (title is null) continue;

        var year = Year.Create(reader.GetInt32(offset++));
        if (year is null) continue;

        var origin = Country.Create(reader.GetNullableString(offset++));
        if (origin is null) continue;

        var minutes = reader.GetInt32(offset++);
        if (minutes < 0) continue;
        var minutage = TimeSpan.FromMinutes(minutes);

        var movie = Movie.Create(title, year, origin, minutage);

        var originalTitle = Title.Create(reader.GetNullableString(offset++));
        if (originalTitle is not null) movie = movie with { OriginalTitle = originalTitle };

        var names = GetNames(reader, offset, nbDirectors);
        names.ForEach(director => movie = AddUniqueDirector(movie, director));
        offset += nbDirectors;

        names = GetNames(reader, offset, nbActors);
        names.ForEach(actor => movie = AddUniqueActor(movie, actor));
        offset += nbActors;

        names = GetNames(reader, offset, nbScriptwriters);
        names.ForEach(scriptwriter => movie = AddUniqueScriptwriter(movie, scriptwriter));
        offset += nbScriptwriters;

        names = GetNames(reader, offset, nbAssistantDirectors);
        names.ForEach(assistantDirector => movie = AddUniqueAssistantDirector(movie, assistantDirector));
        offset += nbAssistantDirectors;

        names = GetNames(reader, offset, 1);
        names.ForEach(basedOn => movie = AddUniqueOriginalWriter(movie, basedOn));
        offset++;

        names = GetNames(reader, offset, 1);
        names.ForEach(dialogWriter => movie = AddUniqueDialogWriter(movie, dialogWriter));
        offset++;

        names = GetNames(reader, offset, 1);
        names.ForEach(photographer => movie = AddUniquePhotographer(movie, photographer));
        offset++;

        names = GetNames(reader, offset, 1);
        names.ForEach(editing => movie = AddUniqueEditing(movie, editing));
        offset++;

        names = GetNames(reader, offset, 1);
        names.ForEach(music => movie = AddUniqueMusic(movie, music));

        yield return movie;
    }
}

static IEnumerable<NameType> GetNames(DbDataReader reader, int offset, int maxCount)
{
    for (var i = 0; i < maxCount; i++)
    {
        var name = Name.Create(reader.GetNullableString(offset++));
        if (name is null) yield break;
        yield return name;
    }
}