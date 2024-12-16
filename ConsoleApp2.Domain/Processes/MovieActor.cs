namespace ConsoleApp2.Domain.Processes;
public static class AddActorDefaults
{
    public static AddParticipant AddAnyActor => (movie, actor) =>
        movie with { Actors = [.. movie.Actors, actor] };
    public static AddParticipant AddUniqueActor => (movie, actor) =>
        movie.Actors.Contains(actor)
        ? movie
        : movie with { Actors = [.. movie.Actors, actor] };
}