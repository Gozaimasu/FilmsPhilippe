namespace ConsoleApp2.Domain.Processes;

public static class AddEditingDefaults
{
    public static AddParticipant AddAnyEditing => (movie, editing) =>
        movie with { Editing = [.. movie.Editing, editing] };
    public static AddParticipant AddUniqueEditing => (movie, editing) =>
        movie.Editing.Contains(editing)
        ? movie
        : movie with { Editing = [.. movie.Editing, editing] };
}