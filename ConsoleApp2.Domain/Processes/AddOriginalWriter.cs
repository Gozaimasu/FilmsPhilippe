using ConsoleApp2.Domain.Models;

namespace ConsoleApp2.Domain.Processes;

public delegate MovieType AddOriginalWriter(MovieType movie, PersonType originalWriter);

public static class AddOriginalWriterExtensions
{
    public static Func<PersonType, MovieType> Apply(this AddOriginalWriter strategy, MovieType movie) =>
        originalWriter => strategy(movie, originalWriter);
}

public static class AddOriginalWriterDefaults
{
    public static AddOriginalWriter AddAnyOriginalWriter => (movie, originalWriter) =>
        movie with { OriginalWriters = [.. movie.OriginalWriters, originalWriter] };
    public static AddOriginalWriter AddUniqueOriginalWriter => (movie, originalWriter) =>
        movie.OriginalWriters.Contains(originalWriter)
        ? movie
        : movie with { OriginalWriters = [.. movie.OriginalWriters, originalWriter] };
}