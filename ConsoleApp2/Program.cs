using ConsoleApp2;
using ConsoleApp2.Models;
using ConsoleApp2.Processes;
using System.Data.Odbc;
using static ConsoleApp2.Processes.AddActorDefaults;
using static ConsoleApp2.Processes.AddDirectorDefaults;
using static ConsoleApp2.Processes.FormatMovieDefaults;
using static ConsoleApp2.Processes.FormatNameDefaults;
using static ConsoleApp2.Processes.FormatNameListDefaults;

var connectionString = "Driver={Microsoft Access Driver (*.mdb, *.accdb)}; Dbq=D:\\.net\\FilmsPhilippe\\Databases\\newfilms.accdb; Uid = Admin; Pwd =; ";

var movies = GetMovies(connectionString);

//var namesFormatter = CommaSeparatedNames.Apply(FormatAcademic);
//var movieFormatter = TitleThenNames.Apply(namesFormatter);

//movies
//    .Select(movieFormatter.Invoke)
//    .Select((movie, offset) => $"{(offset + 1)}. {movie}")
//    .ForEach(Console.WriteLine);

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
    OdbcCommand command = new("SELECT TITRE, REALISAT_1, REALISAT_2, ACTEUR_1, ACTEUR_2, ACTEUR_3, ACTEUR_4, ACTEUR_5, ACTEUR_6, ACTEUR_7, ACTEUR_8, ACTEUR_9, ACTEUR_10, ACTEUR_11, ACTEUR_12, ACTEUR_13, ACTEUR_14, ACTEUR_15, ACTEUR_16 FROM FILM");

    using OdbcConnection connection = new(connectionString);
    command.Connection = connection;
    connection.Open();

    var reader = command.ExecuteReader();

    while (reader.Read())
    {
        var title = Title.Create(reader.GetString(0));
        if (title is null) continue;

        var movie = Movie.Create(title, [], []);

        for (int i = 1; i < 3; i++)
        {
            var name = Name.Create(reader.GetNullableString(i));
            if (name is null) break;
            movie = AddUniqueDirector(movie, name);
        }

        for (int i = 3; i < 19; i++)
        {
            var name = Name.Create(reader.GetNullableString(i));
            if (name is null) break;
            movie = AddUniqueActor(movie, name);
        }

        yield return movie;
    }
}