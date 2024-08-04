namespace ConsoleApp2.Models;

public record MovieType(TitleType Title, NameType[] Directors, NameType[] Actors)
{
    public TitleType? OriginalTitle { get; init; }
}

public static class Movie
{
    public static MovieType Create(TitleType title, NameType[] directors, NameType[] actors) =>
        new(title, directors, actors);
}