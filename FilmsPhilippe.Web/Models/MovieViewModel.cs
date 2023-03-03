namespace FilmsPhilippe.Web.Models;

public class MovieViewModel
{
    public PaginatedList<Movie> Movies { get; set; } = default!;
    public string? SearchString { get; set; }
}
