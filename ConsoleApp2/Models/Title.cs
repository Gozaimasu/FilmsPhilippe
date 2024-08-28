namespace ConsoleApp2.Models;

public record TitleType(string Value);

public static class Title
{
    public static TitleType? Create(string? title) =>
        string.IsNullOrWhiteSpace(title) ? null : new TitleType(title.Trim());
}
