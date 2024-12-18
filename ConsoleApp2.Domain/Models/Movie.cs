namespace ConsoleApp2.Domain.Models;

public record MovieType
{
    public int Id { get; init; }
    public required TitleType Title { get; init; }
    public required YearType Year { get; init; }
    public required CountryType Origin { get; init; }
    public required TimeSpan Duration { get; init; }
    public required PersonType[] Directors { get; init; }
    public required PersonType[] Actors { get; init; }
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
    public static MovieType Create(TitleType title, YearType year, CountryType country, TimeSpan duration,
        PersonType[] directors, PersonType[] actors) =>
        new()
        {
            Title = title, Year = year, Origin = country, Duration = duration, Directors = directors, Actors = actors
        };

    public static MovieType Create(TitleType title, YearType year, CountryType country, TimeSpan duration) =>
        Create(title, year, country, duration, [], []);
}