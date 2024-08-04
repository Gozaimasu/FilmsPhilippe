using ConsoleApp2.Models;

namespace ConsoleApp2.Processes;

public delegate MovieType AddAssistantDirector(MovieType movie, NameType assistantDirector);

public static class AddAssistantDirectorExtensions
{
    public static Func<NameType, MovieType> Apply(this AddAssistantDirector strategy, MovieType movie) =>
        assistantDirector => strategy(movie, assistantDirector);
}

public static class AddAssistantDirectorDefaults
{
    public static AddAssistantDirector AddAnyAssistantDirector => (movie, assistantDirector) =>
        movie with { AssistantDirectors = [.. movie.AssistantDirectors, assistantDirector] };
    public static AddAssistantDirector AddUniqueAssistantDirector => (movie, assistantDirector) =>
        movie.AssistantDirectors.Contains(assistantDirector)
        ? movie
        : movie with { AssistantDirectors = [.. movie.AssistantDirectors, assistantDirector] };
}