
namespace ConsoleApp2.Domain.Models;

public record MovieType(TitleType Title, YearType Year, CountryType Origin, TimeSpan Duration, PersonType[] Directors, PersonType[] Actors)
{
    public TitleType? OriginalTitle { get; init; }
    public PersonType[] ScriptWriters { get; init; } = [];
    public PersonType[] AssistantDirectors { get; init; } = [];
    public PersonType[] OriginalWriters { get; init; } = [];
    public PersonType[] Photographers { get; init; } = [];
    public PersonType[] DialogueWriters { get; init; } = [];
    public PersonType[] Editing { get; init; } = [];
    public PersonType[] Music { get; init; } = [];
}

public static class Movie
{
    public static MovieType Create(TitleType title, YearType year, CountryType country, TimeSpan duration, PersonType[] directors, PersonType[] actors) =>
        new(title, year, country, duration, directors, actors);
    public static MovieType Create(TitleType title, YearType year, CountryType country, TimeSpan duration) =>
        new(title, year, country, duration, [], []);
}