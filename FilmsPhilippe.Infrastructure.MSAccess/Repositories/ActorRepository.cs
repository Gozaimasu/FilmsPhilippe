using FilmsPhilippe.Application.Repositories;
using FilmsPhilippe.Domain.Models;
using Microsoft.Extensions.Configuration;
using System.Data.Odbc;
using System.Text;

namespace FilmsPhilippe.Infrastructure.MSAccess.Repositories;

internal class ActorRepository : IActorRepository
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public ActorRepository(IConfiguration configuration)
    {
        _configuration = configuration;

        _connectionString = _configuration.GetConnectionString("Philippe") ?? throw new ApplicationException("La connectionString est vide");
    }

    public IEnumerable<Actor> List()
    {
        StringBuilder sb = new();
        sb.Append("SELECT DISTINCT ACTEUR_1 FROM (");
        for (int i = 1; i <= 16; i++)
        {
            sb.Append(GetQueryActor(i));
            if (i != 16)
            {
                sb.Append(" UNION ");
            }
        }
        sb.Append(')');
        OdbcCommand command = new(sb.ToString());

        using OdbcConnection connection = new(_connectionString);
        command.Connection = connection;
        connection.Open();
        var reader = command.ExecuteReader();
        while (reader.Read())
        {
            Actor actor = new()
            {
                Name = reader.GetString(0)
            };
            yield return actor;
        }
    }

    private static string GetQueryActor(int i)
    {
        return $"SELECT DISTINCT ACTEUR_{i} FROM FILM WHERE ACTEUR_{i} IS NOT NULL";
    }
}
