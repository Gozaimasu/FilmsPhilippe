namespace ConsoleApp2.Domain.Models;

public record MovieType
{
    public int Id { get; init; }
    public required TitleType Title { get; init; }
    public required YearType Year { get; init; }
    public required CountryType Origin { get; init; }
    public required TimeSpan Duration { get; init; }
    public ICollection<PersonType> Directors { get; init; } = [];
    public ICollection<PersonType> Actors { get; init; } = [];
    public TitleType? OriginalTitle { get; init; }
    public ICollection<PersonType> ScriptWriters { get; init; } = [];
    public ICollection<PersonType> AssistantDirectors { get; init; } = [];
    public ICollection<PersonType> OriginalWriters { get; init; } = [];
    public ICollection<PersonType> Photographers { get; init; } = [];
    public ICollection<PersonType> DialogueWriters { get; init; } = [];
    public ICollection<PersonType> Editing { get; init; } = [];
    public ICollection<PersonType> Music { get; init; } = [];
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