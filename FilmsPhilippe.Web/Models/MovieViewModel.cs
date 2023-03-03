using FilmsPhilippe.Domain.Models;

namespace FilmsPhilippe.Web.Models;

public class MovieViewModel
{
    public List<Movie> Movies { get; set; } = default!;
    public string? SearchString { get; set; }
}
