using ConsoleApp2;
using ConsoleApp2.Models;
using System.Data.Odbc;
using static ConsoleApp2.Processes.AddActorDefaults;
using static ConsoleApp2.Processes.AddDirectorDefaults;

var connectionString = "Driver={Microsoft Access Driver (*.mdb, *.accdb)}; Dbq=D:\\.net\\FilmsPhilippe\\Databases\\newfilms.accdb; Uid = Admin; Pwd =; ";

var movies = GetMovies(connectionString);

Console.WriteLine($"Il y a {movies.Count():n0} films");
Console.WriteLine();

var actors = movies.SelectMany(m => m.Actors);
Console.WriteLine($"Il y a {actors.Count():n0} acteurs");
Console.WriteLine($"Il y a {actors.Distinct().Count():n0} acteurs différents");
Console.WriteLine();

var directors = movies.SelectMany(m => m.Directors);
Console.WriteLine($"Il y a {directors.Count():n0} réalisateurs");
Console.WriteLine($"Il y a {directors.Distinct().Count():n0} réalisateurs différents");

static IEnumerable<MovieType> GetMovies(string connectionString)
{
    OdbcCommand command = new("SELECT TITRE, ANNEE, TITRE_OR, REALISAT_1, REALISAT_2, ACTEUR_1, ACTEUR_2, ACTEUR_3, ACTEUR_4, ACTEUR_5, ACTEUR_6, ACTEUR_7, ACTEUR_8, ACTEUR_9, ACTEUR_10, ACTEUR_11, ACTEUR_12, ACTEUR_13, ACTEUR_14, ACTEUR_15, ACTEUR_16 FROM FILM");
    const int nbDirectors = 2;
    const int nbActors = 16;

    using OdbcConnection connection = new(connectionString);
    command.Connection = connection;
    connection.Open();

    var reader = command.ExecuteReader();

    while (reader.Read())
    {
        int offset = 0;
        var title = Title.Create(reader.GetString(offset++));
        if (title is null) continue;

        var year = Year.Create(reader.GetInt32(offset++));
        if (year is null) continue;

        var movie = Movie.Create(title, year, [], []);

        var originalTitle = Title.Create(reader.GetNullableString(offset++));
        if(originalTitle is not null) movie = movie with { OriginalTitle = originalTitle };

        var offsetDirectors = offset;
        for (int i = 0; i < nbDirectors; i++)
        {
            var name = Name.Create(reader.GetNullableString(offset++));
            if (name is null) break;
            movie = AddUniqueDirector(movie, name);
        }
        offset = offsetDirectors + nbDirectors;

        var offsetActors = offset;
        for (int i = 0; i < nbActors; i++)
        {
            var name = Name.Create(reader.GetNullableString(offset++));
            if (name is null) break;
            movie = AddUniqueActor(movie, name);
        }
        offset = offsetActors + nbActors;

        yield return movie;
    }
}