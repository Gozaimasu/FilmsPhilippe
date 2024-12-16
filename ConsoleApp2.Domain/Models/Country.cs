namespace ConsoleApp2.Domain.Models;

public record CountryType(string Name);

public static class Country
{
    public static CountryType? Create(string? name) =>
        string.IsNullOrWhiteSpace(name) ? null : new CountryType(name.Trim());
}
