namespace Movies.Domain;

/// <summary>
/// Film
/// </summary>
public class Movie
{
    /// <summary>
    /// Identifiant d'un film
    /// </summary>
    public Guid Id { get; set; } = Guid.Empty;
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
    /// Identité du réalisateur
    /// </summary>
    public string? Realisateur1 { get; set; }
    /// <summary>
    /// Identité du second réalisateur
    /// </summary>
    public string? Realisateur2 { get; set; }
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
    /// Acteur 1
    /// </summary>
    public string? Acteur1 { get; set; }
    /// <summary>
    /// Acteur 2
    /// </summary>
    public string? Acteur2 { get; set; }
    /// <summary>
    /// Acteur 3
    /// </summary>
    public string? Acteur3 { get; set; }
    /// <summary>
    /// Acteur 4
    /// </summary>
    public string? Acteur4 { get; set; }
    /// <summary>
    /// Acteur 5
    /// </summary>
    public string? Acteur5 { get; set; }
    /// <summary>
    /// Acteur 6
    /// </summary>
    public string? Acteur6 { get; set; }
    /// <summary>
    /// Acteur 7
    /// </summary>
    public string? Acteur7 { get; set; }
    /// <summary>
    /// Acteur 8
    /// </summary>
    public string? Acteur8 { get; set; }
    /// <summary>
    /// Acteur 9
    /// </summary>
    public string? Acteur9 { get; set; }
    /// <summary>
    /// Acteur 10
    /// </summary>
    public string? Acteur10 { get; set; }
    /// <summary>
    /// Acteur 11
    /// </summary>
    public string? Acteur11 { get; set; }
    /// <summary>
    /// Acteur 12
    /// </summary>
    public string? Acteur12 { get; set; }
    /// <summary>
    /// Acteur 13
    /// </summary>
    public string? Acteur13 { get; set; }
    /// <summary>
    /// Acteur 14
    /// </summary>
    public string? Acteur14 { get; set; }
    /// <summary>
    /// Acteur 15
    /// </summary>
    public string? Acteur15 { get; set; }
    /// <summary>
    /// Acteur 16
    /// </summary>
    public string? Acteur16 { get; set; }
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
}
