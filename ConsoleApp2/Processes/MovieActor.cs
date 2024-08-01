using ConsoleApp2.Models;

namespace ConsoleApp2.Processes;

public delegate MovieType AddActor(MovieType movie, NameType actor);

public static class AddActorExtensions
{
    public static Func<NameType, MovieType> Apply(this AddActor strategy, MovieType movie) =>
        actor => strategy(movie, actor);
}

public static class AddActorDefaults
{
    public static AddActor AddAnyActor => (movie, actor) =>
        movie with { Directors = [.. movie.Directors, actor] };
    public static AddActor AddUniqueActor => (movie, actor) =>
        movie.Actors.Contains(actor)
        ? movie
        : movie with { Actors = [.. movie.Actors, actor] };
}