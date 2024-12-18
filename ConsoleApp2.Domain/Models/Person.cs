namespace ConsoleApp2.Domain.Models;

public record PersonType(NameType Name);

public static class Person
{
    public static PersonType Create(NameType name) =>
        new(name);
}