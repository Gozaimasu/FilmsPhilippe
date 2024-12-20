namespace ConsoleApp2.Domain.Processes;

public static class AddPhotographerDefaults
{
    public static AddParticipant AddAnyPhotographer => (movie, photographer) =>
        movie with { Photographers = [.. movie.Photographers, photographer] };
    public static AddParticipant AddUniquePhotographer => (movie, photographer) =>
        movie.Photographers.Contains(photographer)
        ? movie
        : movie with { Photographers = [.. movie.Photographers, photographer] };
}