using ConsoleApp2.Models;

namespace ConsoleApp2.Processes;

public delegate MovieType AddDirector(MovieType movie, NameType director);

public static class AddDirectorExtensions
{
    public static Func<NameType, MovieType> Apply(this AddDirector strategy, MovieType movie) =>
        director => strategy(movie, director);
}

public static class AddDirectorDefaults
{
    public static AddDirector AddAnyDirector => (movie, director) =>
        movie with { Directors = [.. movie.Directors, director] };
    public static AddDirector AddUniqueDirector => (movie, director) =>
        movie.Directors.Contains(director)
        ? movie
        : movie with { Directors = [.. movie.Directors, director] };
}