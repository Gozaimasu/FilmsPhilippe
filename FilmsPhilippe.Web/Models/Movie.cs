using System.ComponentModel.DataAnnotations;

namespace FilmsPhilippe.Web.Models;

public class Movie
{
    public string Title { get; set; } = string.Empty;

    [Display(Name = "Original Title")]
    public string? OriginalTitle { get; set; }

    [Display(Name = "Release Date")]
    public DateTime ReleaseDate { get; set; }
}
