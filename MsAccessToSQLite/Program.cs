using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MsAccessToSQLite;
using System.Data.Odbc;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddDbContext<MoviesDbContext>((sp, b) =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    var sqLiteConnectionString = configuration.GetConnectionString("SQLite");
    b.UseSqlite(sqLiteConnectionString);
});

using IHost host = builder.Build();

using var scope = host.Services.CreateScope();
var serviceProvider = scope.ServiceProvider;
using var context = serviceProvider.GetRequiredService<MoviesDbContext>();
context.Database.EnsureCreated();

Console.WriteLine("Database created");

using OdbcCommand command = new("SELECT TITRE, TITRE_OR, ANNEE, ORIGINE, MINUTAGE, VISION, QUI, REALISAT_1, REALISAT_2, SCENARIO, SCENARIO1, D_APRES, " +
"DIALOGUE, PHOTO, MONTAGE, MUSIQUE, ASS_REAL_1, ASS_REAL_2, ASS_REAL_3, ACTEUR_1, ACTEUR_2, ACTEUR_3, ACTEUR_4, ACTEUR_5, ACTEUR_6, ACTEUR_7, " +
"ACTEUR_8, ACTEUR_9, ACTEUR_10, ACTEUR_11, ACTEUR_12, ACTEUR_13, ACTEUR_14, ACTEUR_15, ACTEUR_16, OU, RESUMAID, COMPLET, verificationcd, dervision FROM FILM");

var configuration = serviceProvider.GetRequiredService<IConfiguration>();
var msAccessConnectionString = configuration.GetConnectionString("MSAccess");
using OdbcConnection connection = new(msAccessConnectionString);
command.Connection = connection;
connection.Open();

using var reader = command.ExecuteReader();

int count = 0;
while (reader.Read())
{
    int offset = 0;
    var title = reader.GetString(offset++);
    if (title is null) continue;
    try
    {
        var movie = new Movie
        {
            Titre = title,
            TitreOriginal = reader.GetValue(offset++) as string,
            Annee = reader.GetInt32(offset++),
            Origine = reader.GetString(offset++),
            Minutage = reader.GetInt32(offset++),
            Vision = reader.GetInt32(offset++),
            Qui = reader.GetString(offset++),
            Realisateur1 = reader.GetValue(offset++) as string,
            Realisateur2 = reader.GetValue(offset++) as string,
            Scenario = reader.GetValue(offset++) as string,
            Scenario1 = reader.GetValue(offset++) as string, // 10
            DApres = reader.GetValue(offset++) as string,
            Dialogue = reader.GetValue(offset++) as string,
            Photo = reader.GetValue(offset++) as string,
            Montage = reader.GetValue(offset++) as string,
            Musique = reader.GetValue(offset++) as string,
            AssistantRealisateur1 = reader.GetValue(offset++) as string,
            AssistantRealisateur2 = reader.GetValue(offset++) as string,
            AssistantRealisateur3 = reader.GetValue(offset++) as string,
            Acteur1 = reader.GetValue(offset++) as string,
            Acteur2 = reader.GetValue(offset++) as string, // 20
            Acteur3 = reader.GetValue(offset++) as string,
            Acteur4 = reader.GetValue(offset++) as string,
            Acteur5 = reader.GetValue(offset++) as string,
            Acteur6 = reader.GetValue(offset++) as string,
            Acteur7 = reader.GetValue(offset++) as string,
            Acteur8 = reader.GetValue(offset++) as string,
            Acteur9 = reader.GetValue(offset++) as string,
            Acteur10 = reader.GetValue(offset++) as string,
            Acteur11 = reader.GetValue(offset++) as string,
            Acteur12 = reader.GetValue(offset++) as string, // 30
            Acteur13 = reader.GetValue(offset++) as string,
            Acteur14 = reader.GetValue(offset++) as string,
            Acteur15 = reader.GetValue(offset++) as string,
            Acteur16 = reader.GetValue(offset++) as string,
            Ou = reader.GetValue(offset++) as string,
            Resume = reader.GetString(offset++),
            Complet = reader.GetInt32(offset++),
            VerificationCD = reader.GetInt32(offset++),
            Dervision = reader.GetString(offset++)
        };

        context.Movies.Add(movie);
        context.SaveChanges();

        count++;
        if(count % 100 == 0)
        {
            Console.WriteLine($"{count} films");
        }
    }
    catch
    {
        Console.WriteLine($"{title}, offset = {offset}");
        throw;
    }
}

count = context.Movies.Count();
Console.WriteLine($"Total count: {count}");