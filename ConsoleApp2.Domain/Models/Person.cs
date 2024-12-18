namespace ConsoleApp2.Domain.Models;

public record PersonType
{
    public int Id { get; init; }
    public required NameType Name { get; init; }

    public IEnumerable<MovieType> Movies { get; init; } = [];
}

public static class Person
{
    public static PersonType Create(NameType name) =>
        new() { Name = name };
}