namespace ConsoleApp2.Processes;

public static class AddDirectorDefaults
{
    public static AddParticipant AddAnyDirector => (movie, director) =>
        movie with { Directors = [.. movie.Directors, director] };
    public static AddParticipant AddUniqueDirector => (movie, director) =>
        movie.Directors.Contains(director)
        ? movie
        : movie with { Directors = [.. movie.Directors, director] };
}