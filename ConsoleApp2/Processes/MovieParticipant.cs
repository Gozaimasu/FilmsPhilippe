using ConsoleApp2.Models;

namespace ConsoleApp2.Processes;

public delegate MovieType AddParticipant(MovieType movie, NameType participant);

public static class AddParticipantExtensions
{
    public static Func<NameType, MovieType> Apply(this AddParticipant strategy, MovieType movie) =>
        participant => strategy(movie, participant);
}
