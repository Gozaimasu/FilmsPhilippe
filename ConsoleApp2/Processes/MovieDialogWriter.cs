using ConsoleApp2.Models;

namespace ConsoleApp2.Processes;

public delegate MovieType AddDialogWriter(MovieType movie, NameType dialogWriter);

public static class AddDialogWriterExtensions
{
    public static Func<NameType, MovieType> Apply(this AddDialogWriter strategy, MovieType movie) =>
        dialogWriter => strategy(movie, dialogWriter);
}

public static class AddDialogWriterDefaults
{
    public static AddDialogWriter AddAnyDialogWriter => (movie, dialogWriter) =>
        movie with { DialogueWriters = [.. movie.DialogueWriters, dialogWriter] };
    public static AddDialogWriter AddUniqueDialogWriter => (movie, dialogWriter) =>
        movie.DialogueWriters.Contains(dialogWriter)
        ? movie
        : movie with { DialogueWriters = [.. movie.DialogueWriters, dialogWriter] };
}