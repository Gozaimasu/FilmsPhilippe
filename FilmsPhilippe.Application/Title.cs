namespace FilmsPhilippe.Application;

public static class Title
{
    public static TitleType? Create(string title) =>
        string.IsNullOrWhiteSpace(title) ? null : new(title.Trim());
}
