namespace ConsoleApp2.Processes;

public static class AddScriptwriterDefaults
{
    public static AddParticipant AddAnyScriptwriter => (movie, scriptwriter) =>
        movie with { ScriptWriters = [.. movie.ScriptWriters, scriptwriter] };
    public static AddParticipant AddUniqueScriptwriter => (movie, scriptwriter) =>
        movie.ScriptWriters.Contains(scriptwriter)
        ? movie
        : movie with { ScriptWriters = [.. movie.ScriptWriters, scriptwriter] };
}