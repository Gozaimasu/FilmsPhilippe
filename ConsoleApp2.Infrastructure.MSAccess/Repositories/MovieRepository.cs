using System.Data.Common;
using System.Data.Odbc;
using System.Runtime.CompilerServices;
using ConsoleApp2.Domain;
using ConsoleApp2.Domain.Models;
using ConsoleApp2.Domain.Repositories;
using ConsoleApp2.Infrastructure.MSAccess.Extensions;
using Microsoft.Extensions.Configuration;
using static ConsoleApp2.Domain.Processes.AddActorDefaults;
using static ConsoleApp2.Domain.Processes.AddAssistantDirectorDefaults;
using static ConsoleApp2.Domain.Processes.AddDialogWriterDefaults;
using static ConsoleApp2.Domain.Processes.AddDirectorDefaults;
using static ConsoleApp2.Domain.Processes.AddEditingDefaults;
using static ConsoleApp2.Domain.Processes.AddMusicDefaults;
using static ConsoleApp2.Domain.Processes.AddOriginalWriterDefaults;
using static ConsoleApp2.Domain.Processes.AddPhotographerDefaults;
using static ConsoleApp2.Domain.Processes.AddScriptwriterDefaults;

namespace ConsoleApp2.Infrastructure.MSAccess.Repositories;

internal sealed class MovieRepository : IMovieRepository
{
    private readonly string _connectionString;

    public MovieRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("MSAccess")
            ?? throw new ApplicationException("MSAccess connection string is missing.");
    }
    
    public Task<int> AddAsync(MovieType movie, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public Task AddRangeAsync(IEnumerable<MovieType> movies, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public async IAsyncEnumerable<MovieType> GetAllAsync([EnumeratorCancellation] CancellationToken token = default)
    {
        OdbcCommand command =
            new(
                "SELECT TITRE, ANNEE, ORIGINE, MINUTAGE, TITRE_OR, REALISAT_1, REALISAT_2, ACTEUR_1, ACTEUR_2, ACTEUR_3, ACTEUR_4, ACTEUR_5, ACTEUR_6, ACTEUR_7, ACTEUR_8, ACTEUR_9, ACTEUR_10, ACTEUR_11, ACTEUR_12, ACTEUR_13, ACTEUR_14, ACTEUR_15, ACTEUR_16, SCENARIO, SCENARIO1, ASS_REAL_1, ASS_REAL_2, ASS_REAL_3, D_APRES, DIALOGUE, PHOTO, MONTAGE, MUSIQUE FROM FILM");
        const int nbDirectors = 2;
        const int nbActors = 16;
        const int nbScriptwriters = 2;
        const int nbAssistantDirectors = 3;

        await using OdbcConnection connection = new(_connectionString);
        command.Connection = connection;
        connection.Open();

        var reader = await command.ExecuteReaderAsync(token);

        while (await reader.ReadAsync(token))
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
            names.ForEach(name =>
            {
                var director = Person.Create(name);
                movie = AddUniqueDirector(movie, director);
            });
            offset += nbDirectors;

            names = GetNames(reader, offset, nbActors);
            names.ForEach(name =>
            {
                var actor = Person.Create(name);
                movie = AddUniqueActor(movie, actor);
            });
            offset += nbActors;

            names = GetNames(reader, offset, nbScriptwriters);
            names.ForEach(name =>
            {
                var scriptwriter = Person.Create(name);
                movie = AddUniqueScriptwriter(movie, scriptwriter);
            });
            offset += nbScriptwriters;

            names = GetNames(reader, offset, nbAssistantDirectors);
            names.ForEach(name =>
            {
                var assistantDirector = Person.Create(name);
                movie = AddUniqueAssistantDirector(movie, assistantDirector);
            });
            offset += nbAssistantDirectors;

            names = GetNames(reader, offset, 1);
            names.ForEach(name =>
            {
                var basedOn = Person.Create(name);
                movie = AddUniqueOriginalWriter(movie, basedOn);
            });
            offset++;

            names = GetNames(reader, offset, 1);
            names.ForEach(name =>
            {
                var dialogWriter = Person.Create(name);
                movie = AddUniqueDialogWriter(movie, dialogWriter);
            });
            offset++;

            names = GetNames(reader, offset, 1);
            names.ForEach(name =>
            {
                var photographer = Person.Create(name);
                movie = AddUniquePhotographer(movie, photographer);
            });
            offset++;

            names = GetNames(reader, offset, 1);
            names.ForEach(name =>
            {
                var editing = Person.Create(name);
                movie = AddUniqueEditing(movie, editing);
            });
            offset++;

            names = GetNames(reader, offset, 1);
            names.ForEach(name =>
            {
                var music = Person.Create(name);
                movie = AddUniqueMusic(movie, music);
            });

            yield return movie;
        }
    }

    private static IEnumerable<NameType> GetNames(DbDataReader reader, int offset, int maxCount)
    {
        for (var i = 0; i < maxCount; i++)
        {
            var name = Name.Create(reader.GetNullableString(offset++));
            if (name is null) yield break;
            yield return name;
        }
    }

    public Task<MovieType?> GetAsync(int id, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }
}