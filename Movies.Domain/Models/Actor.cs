namespace Movies.Domain.Models;

/// <summary>
/// Acteur
/// </summary>
public class Actor
{
    /// <summary>
    /// Identifiant de l'acteur
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Nom de l'acteur
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Liste des films de l'acteur
    /// </summary>
    public List<Movie> Movies { get; set; } = [];
}
