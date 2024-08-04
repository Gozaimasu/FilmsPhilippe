using ConsoleApp2.Models;

namespace ConsoleApp2.Processes;

public delegate MovieType AddPhotographer(MovieType movie, NameType photographer);

public static class AddPhotographerExtensions
{
    public static Func<NameType, MovieType> Apply(this AddPhotographer strategy, MovieType movie) =>
        photographer => strategy(movie, photographer);
}

public static class AddPhotographerDefaults
{
    public static AddPhotographer AddAnyPhotographer => (movie, photographer) =>
        movie with { Photographers = [.. movie.Photographers, photographer] };
    public static AddPhotographer AddUniquePhotographer => (movie, photographer) =>
        movie.Photographers.Contains(photographer)
        ? movie
        : movie with { Photographers = [.. movie.Photographers, photographer] };
}