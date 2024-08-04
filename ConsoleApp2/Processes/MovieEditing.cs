using ConsoleApp2.Models;

namespace ConsoleApp2.Processes;

public delegate MovieType AddEditing(MovieType movie, NameType editing);

public static class AddEditingExtensions
{
    public static Func<NameType, MovieType> Apply(this AddEditing strategy, MovieType movie) =>
        editing => strategy(movie, editing);
}

public static class AddEditingDefaults
{
    public static AddEditing AddAnyEditing => (movie, editing) =>
        movie with { Editing = [.. movie.Editing, editing] };
    public static AddEditing AddUniqueEditing => (movie, editing) =>
        movie.Editing.Contains(editing)
        ? movie
        : movie with { Editing = [.. movie.Editing, editing] };
}