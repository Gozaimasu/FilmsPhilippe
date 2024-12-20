using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Movies.Domain.Models;
using Movies.Domain.Repositories;
using Movies.Infrastructure.SQLite.Extensions;
using System.Data.Odbc;
using System.Diagnostics;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSQLite();

using var host = builder.Build();

using var scope = host.Services.CreateScope();
var serviceProvider = scope.ServiceProvider;

var movies = new List<Movie>();
int total;

var configuration = serviceProvider.GetRequiredService<IConfiguration>();
var msAccessConnectionString = configuration.GetConnectionString("MSAccess");
using (OdbcConnection connection = new(msAccessConnectionString))
{
    connection.Open();

    using (OdbcCommand command = new("SELECT COUNT(*) FROM FILM"))
    {
        command.Connection = connection;
        using var reader = command.ExecuteReader();
        reader.Read();
        total = reader.GetInt32(0);
    }

    using (OdbcCommand command = new("SELECT TITRE, TITRE_OR, ANNEE, ORIGINE, MINUTAGE, VISION, QUI, REALISAT_1, REALISAT_2, SCENARIO, SCENARIO1, D_APRES, " +
    "DIALOGUE, PHOTO, MONTAGE, MUSIQUE, ASS_REAL_1, ASS_REAL_2, ASS_REAL_3, ACTEUR_1, ACTEUR_2, ACTEUR_3, ACTEUR_4, ACTEUR_5, ACTEUR_6, ACTEUR_7, " +
    "ACTEUR_8, ACTEUR_9, ACTEUR_10, ACTEUR_11, ACTEUR_12, ACTEUR_13, ACTEUR_14, ACTEUR_15, ACTEUR_16, OU, RESUMAID, COMPLET, verificationcd, dervision FROM FILM"))
    {
        command.Connection = connection;

        using var reader = command.ExecuteReader();

        var count = 0;
        while (reader.Read())
        {
            var offset = 0;
            var title = reader.GetString(0);
            try
            {
                var movie = new Movie
                {
                    Titre = title,
                    TitreOriginal = reader.GetValue(1) as string,
                    Annee = reader.GetInt32(2),
                    Origine = reader.GetString(3),
                    Minutage = reader.GetInt32(4),
                    Vision = reader.GetInt32(5),
                    Qui = reader.GetString(6),
                    Scenario = reader.GetValue(9) as string,
                    Scenario1 = reader.GetValue(10) as string, // 10
                    DApres = reader.GetValue(11) as string,
                    Dialogue = reader.GetValue(12) as string,
                    Photo = reader.GetValue(13) as string,
                    Montage = reader.GetValue(14) as string,
                    Musique = reader.GetValue(15) as string,
                    AssistantRealisateur1 = reader.GetValue(16) as string,
                    AssistantRealisateur2 = reader.GetValue(17) as string,
                    AssistantRealisateur3 = reader.GetValue(18) as string,
                    Ou = reader.GetValue(35) as string,
                    Resume = reader.GetString(36),
                    Complet = reader.GetInt32(37),
                    VerificationCD = reader.GetInt32(38),
                    Dervision = reader.GetString(39)
                };

                offset = 7;
                do
                {
                    if (reader.GetValue(offset++) is not string directorName) break;
                    movie.Directors.Add(new Director() { Name = directorName });
                } while (offset < 9);

                offset = 19;
                do
                {
                    if (reader.GetValue(offset++) is not string actorName) break;
                    movie.Actors.Add(new Actor() { Name = actorName });
                } while (offset < 35);

                movies.Add(movie);

                count++;
                if (count % 100 == 0)
                {
                    Console.WriteLine($"{count} films / {total}");
                }
            }
            catch
            {
                Console.WriteLine($"{title}, offset = {offset}");
                throw;
            }
        }
    }
}

var movieRepository = serviceProvider.GetRequiredService<IMovieRepository>();
var start = Stopwatch.GetTimestamp();
Console.WriteLine("Ajout des films");
movieRepository.AddRangeAsync(movies).Wait();
var elapsed = Stopwatch.GetElapsedTime(start);

Console.WriteLine($"{total} movies added in {elapsed}");