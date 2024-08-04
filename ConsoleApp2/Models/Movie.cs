namespace ConsoleApp2.Models;

public record MovieType(TitleType Title, YearType Year, NameType[] Directors, NameType[] Actors)
{
    public TitleType? OriginalTitle { get; init; }
}

public static class Movie
{
    public static MovieType Create(TitleType title, YearType year, NameType[] directors, NameType[] actors) =>
        new(title, year, directors, actors);
}