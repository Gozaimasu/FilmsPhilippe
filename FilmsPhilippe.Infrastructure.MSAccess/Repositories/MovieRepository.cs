using FilmsPhilippe.Application.Repositories;
using FilmsPhilippe.Domain.Models;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.Odbc;

namespace FilmsPhilippe.Infrastructure.MSAccess.Repositories;

internal class MovieRepository : IMovieRepository
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public MovieRepository(IConfiguration configuration)
    {
        _configuration = configuration;

        _connectionString = _configuration.GetConnectionString("Philippe") ?? throw new ApplicationException("La connectionString est vide");
    }

    public IEnumerable<Movie> List()
    {
        OdbcCommand command = new("SELECT TITRE, TITRE_OR, ANNEE FROM FILM");

        using OdbcConnection connection = new(_connectionString);
        command.Connection = connection;
        connection.Open();
        var reader = command.ExecuteReader();
        while (reader.Read())
        {
            int annee;
            try
            {
                annee = Convert.ToInt32(reader.GetDouble("ANNEE"));
            }
            catch (OverflowException)
            {
                // TODO, ajouter un log
                continue;
            }
            Movie movie = new()
            {
                Title = reader.GetString("TITRE"),
                OriginalTitle = reader.IsDBNull("TITRE_OR") ? null : reader.GetString("TITRE_OR"),
                ReleaseDate = new DateTime().AddYears(annee),
            };
            yield return movie;
        }
    }
}
