namespace ConsoleApp2.Domain.Processes;

public static class AddAssistantDirectorDefaults
{
    public static AddParticipant AddAnyAssistantDirector => (movie, assistantDirector) =>
        movie with { AssistantDirectors = [.. movie.AssistantDirectors, assistantDirector] };
    public static AddParticipant AddUniqueAssistantDirector => (movie, assistantDirector) =>
        movie.AssistantDirectors.Contains(assistantDirector)
        ? movie
        : movie with { AssistantDirectors = [.. movie.AssistantDirectors, assistantDirector] };
}