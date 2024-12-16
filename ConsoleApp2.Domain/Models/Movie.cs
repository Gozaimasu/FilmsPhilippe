
namespace ConsoleApp2.Domain.Models;

public record MovieType(TitleType Title, YearType Year, CountryType Origin, TimeSpan Duration, NameType[] Directors, NameType[] Actors)
{
    public TitleType? OriginalTitle { get; init; }
    public NameType[] ScriptWriters { get; init; } = [];
    public NameType[] AssistantDirectors { get; init; } = [];
    public NameType[] OriginalWriters { get; init; } = [];
    public NameType[] Photographers { get; init; } = [];
    public NameType[] DialogueWriters { get; init; } = [];
    public NameType[] Editing { get; init; } = [];
    public NameType[] Music { get; init; } = [];
}

public static class Movie
{
    public static MovieType Create(TitleType title, YearType year, CountryType country, TimeSpan duration, NameType[] directors, NameType[] actors) =>
        new(title, year, country, duration, directors, actors);
    public static MovieType Create(TitleType title, YearType year, CountryType country, TimeSpan duration) =>
        new(title, year, country, duration, [], []);
}