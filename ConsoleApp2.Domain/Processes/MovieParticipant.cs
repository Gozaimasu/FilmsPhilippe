using ConsoleApp2.Domain.Models;

namespace ConsoleApp2.Domain.Processes;

public delegate MovieType AddParticipant(MovieType movie, PersonType participant);

public static class AddParticipantExtensions
{
    public static Func<PersonType, MovieType> Apply(this AddParticipant strategy, MovieType movie) =>
        participant => strategy(movie, participant);
}
