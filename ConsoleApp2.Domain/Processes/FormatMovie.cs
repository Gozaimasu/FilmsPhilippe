using ConsoleApp2.Domain.Models;

namespace ConsoleApp2.Domain.Processes;

public delegate string FormatMovie(MovieType movie);
public delegate string FormatMovieExt(FormatNamesList namesFormatter, MovieType movie);

public static class FormatMovieExtensions
{
    public static FormatMovie Apply(this FormatMovieExt formatter, FormatNamesList namesFormatter) =>
        movie => formatter(namesFormatter, movie);
}

public static class FormatMovieDefaults
{
    public static FormatMovieExt NamesThenTitle => (namesFormatter, movie) =>
        $"{namesFormatter(movie.Directors.Select(d => d.Name))}, {movie.Title.Value}";
    public static FormatMovieExt TitleThenNames => (namesFormatter, movie) =>
        $"{movie.Title.Value} by {namesFormatter(movie.Directors.Select(d => d.Name))} with {namesFormatter(movie.Actors.Select(a => a.Name))}";
}