namespace FilmsPhilippe.Web.Models;

public class ActorViewModel
{
    public PaginatedList<Actor> Actors { get; set; } = default!;
    public string? SearchString { get; set; }
}
