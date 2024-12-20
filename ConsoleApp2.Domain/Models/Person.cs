namespace ConsoleApp2.Domain.Models;

public record PersonType
{
    public int Id { get; init; }
    public required NameType Name { get; init; }

    public ICollection<MovieType> MoviesAsActor { get; } = [];
    public ICollection<MovieType> MoviesAsDirector { get; } = [];
    public ICollection<MovieType> MoviesAsScriptWriter { get; } = [];
    public ICollection<MovieType> MoviesAsAssistantDirector { get; } = [];
    public ICollection<MovieType> MoviesAsOriginalWriter { get; } = [];
    public ICollection<MovieType> MoviesAsPhotographer { get; } = [];
    public ICollection<MovieType> MoviesAsDialogueWriter { get; } = [];
    public ICollection<MovieType> MoviesAsEditing { get; } = [];
    public ICollection<MovieType> MoviesAsMusic { get; } = [];
}

public static class Person
{
    public static PersonType Create(NameType name) =>
        new() { Name = name };
}