using ConsoleApp2.Models;

namespace ConsoleApp2.Processes;

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
        $"{namesFormatter(movie.Directors)}, {movie.Title.Value}";
    public static FormatMovieExt TitleThenNames => (namesFormatter, movie) =>
        $"{movie.Title.Value} by {namesFormatter(movie.Directors)} with {namesFormatter(movie.Actors)}";
}