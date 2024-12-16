namespace Movies.Domain.Models;

/// <summary>
/// Film
/// </summary>
public class Movie
{
    /// <summary>
    /// Identifiant d'un film
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Titre du film
    /// </summary>
    public string Titre { get; set; } = string.Empty;
    /// <summary>
    /// Titre du film en version originale
    /// </summary>
    public string? TitreOriginal { get; set; }
    /// <summary>
    /// Année de sortie du film
    /// </summary>
    public int Annee { get; set; }
    /// <summary>
    /// Origine du film
    /// </summary>
    public string Origine { get; set; } = string.Empty;
    /// <summary>
    /// Durée du film
    /// </summary>
    public int Minutage { get; set; }
    /// <summary>
    /// Nombre de visionnage
    /// </summary>
    public int Vision { get; set; }
    /// <summary>
    /// ???
    /// </summary>
    public string Qui { get; set; } = string.Empty;
    /// <summary>
    /// Identité du scénariste
    /// </summary>
    public string? Scenario { get; set; }
    /// <summary>
    /// Identité du second scénariste
    /// </summary>
    public string? Scenario1 { get; set; }
    /// <summary>
    /// Adapté de
    /// </summary>
    public string? DApres { get; set; }
    /// <summary>
    /// Identité du dialoguiste
    /// </summary>
    public string? Dialogue { get; set; }
    /// <summary>
    /// Photographe
    /// </summary>
    public string? Photo { get; set; }
    /// <summary>
    /// Monteur
    /// </summary>
    public string? Montage { get; set; }
    /// <summary>
    /// Compositeur de la bande originale
    /// </summary>
    public string? Musique { get; set; }
    /// <summary>
    /// Premier assistant réalisateur
    /// </summary>
    public string? AssistantRealisateur1 { get; set; }
    /// <summary>
    /// Second assistant réalisateur
    /// </summary>
    public string? AssistantRealisateur2 { get; set; }
    /// <summary>
    /// Troisième assistant réalisateur
    /// </summary>
    public string? AssistantRealisateur3 { get; set; }
    /// <summary>
    /// ???
    /// </summary>
    public string? Ou { get; set; }
    /// <summary>
    /// ???
    /// </summary>
    public string Resume { get; set; } = string.Empty;
    /// <summary>
    /// 
    /// </summary>
    public int Complet { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int VerificationCD { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string Dervision { get; set; } = string.Empty;

    /// <summary>
    /// Liste des acteurs du film
    /// </summary>
    public List<Actor> Actors { get; set; } = [];
    /// <summary>
    /// Liste des réalisateurs du film
    /// </summary>
    public List<Director> Directors { get; set; } = [];
}
