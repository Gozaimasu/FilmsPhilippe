namespace ConsoleApp2.Domain.Processes;

public static class AddDialogWriterDefaults
{
    public static AddParticipant AddAnyDialogWriter => (movie, dialogWriter) =>
        movie with { DialogueWriters = [.. movie.DialogueWriters, dialogWriter] };
    public static AddParticipant AddUniqueDialogWriter => (movie, dialogWriter) =>
        movie.DialogueWriters.Contains(dialogWriter)
        ? movie
        : movie with { DialogueWriters = [.. movie.DialogueWriters, dialogWriter] };
}