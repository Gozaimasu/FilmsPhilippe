namespace Movies.Domain.Models;

/// <summary>
/// Réalisateur
/// </summary>
public class Director
{
    /// <summary>
    /// Identifiant du réalisateur
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Nom du réalisateur
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Liste des films du réalisateur
    /// </summary>
    public List<Movie> Movies { get; set; } = [];
}
