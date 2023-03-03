

using System.Data.Odbc;

var connectionString = "Driver={Microsoft Access Driver (*.mdb, *.accdb)}; Dbq=Z:\\.net\\FilmsPhilippe\\Databases\\newfilms.accdb; Uid = Admin; Pwd =; ";

string query = GetSelectMovieQuery("TITO ET MOI");
RunQuery(query);

query = GetSelectMovieQuery("NINOTCHKA");
RunQuery(query);

static string GetSelectMovieQuery(string titre)
{
    var query = $@"SELECT TITRE, ANNEE, SCENARIO FROM FILM WHERE TITRE='{titre}';";
    return query;
}

void RunQuery(string query)
{
    OdbcCommand command = new(query);

    using OdbcConnection connection = new(connectionString);
    command.Connection = connection;
    connection.Open();
    var reader = command.ExecuteReader();
    while (reader.Read())
    {
        Console.WriteLine("Titre = {0}, Annee = {1},  Scenario = {2}", reader.GetString(0), reader.GetString(1), reader.GetString(2));
    }
}