namespace ConsoleApp2.Domain.Models;

public abstract record NameType;

public record FullNameType(string FirstName, string LastName) : NameType;
public record MononymType(string Name) : NameType;

public static class NameTypeExtension
{
    public static R Map<R>(this NameType name, Func<FullNameType, R> mapFullName, Func<MononymType, R> mapMononym) =>
        name switch
        {
            FullNameType fn => mapFullName(fn),
            MononymType m => mapMononym(m),
            _ => throw new InvalidOperationException("Unexpected name type")
        };
}

public static class Name
{
    public static NameType? Create(string firstName, string lastname) =>
        string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastname) ? null
        : new FullNameType(firstName, lastname);

    public static NameType? Create(string? mononym) =>
        string.IsNullOrWhiteSpace(mononym) ? null : new MononymType(mononym);

    public static NameType[]? CreateMany(params NameType?[] names) =>
        names.Any(name => name is null) ? null : (NameType[]?)names!;

    public static R Match<R>(this NameType name, Func<string, string, R> fullname, Func<string, R> mononym) =>
        name switch
        {
            FullNameType fn => fullname(fn.FirstName, fn.LastName),
            MononymType m => mononym(m.Name),
            _ => throw new InvalidOperationException("Unexpected name type")
        };
}