namespace FilmsPhilippe.Application;

public static class Movie
{
    public static MovieType? Create(TitleType title, params NameType[] authors) =>
        new(title, authors);
}
