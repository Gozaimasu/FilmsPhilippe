namespace FilmsPhilippe.Domain.Models;

public class Movie
{
    public string Title { get; set; } = string.Empty;
    public string? OriginalTitle { get; set; }
    public DateTime ReleaseDate { get; set; }
}
