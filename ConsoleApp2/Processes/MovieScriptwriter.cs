using ConsoleApp2.Models;

namespace ConsoleApp2.Processes;

public delegate MovieType AddScriptwriter(MovieType movie, NameType scriptwriter);

public static class AddScriptwriterExtensions
{
    public static Func<NameType, MovieType> Apply(this AddScriptwriter strategy, MovieType movie) =>
        scriptwriter => strategy(movie, scriptwriter);
}

public static class AddScriptwriterDefaults
{
    public static AddScriptwriter AddAnyScriptwriter => (movie, scriptwriter) =>
        movie with { ScriptWriters = [.. movie.ScriptWriters, scriptwriter] };
    public static AddScriptwriter AddUniqueScriptwriter => (movie, scriptwriter) =>
        movie.ScriptWriters.Contains(scriptwriter)
        ? movie
        : movie with { ScriptWriters = [.. movie.ScriptWriters, scriptwriter] };
}