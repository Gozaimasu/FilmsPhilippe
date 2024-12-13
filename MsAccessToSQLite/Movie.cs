namespace MsAccessToSQLite;

internal class Movie
{
    public Guid Id { get; set; } = Guid.Empty;
    public string Titre { get; set; } = string.Empty;
    public string? TitreOriginal { get; set; }
    public int Annee { get; set; }
    public string Origine { get; set; } = string.Empty;
    public int Minutage { get; set; }
    public int Vision { get; set; }
    public string Qui { get; set; } = string.Empty;
    public string? Realisateur1 { get; set; }
    public string? Realisateur2 { get; set; }
    public string? Scenario { get; set; }
    public string? Scenario1 { get; set; }
    public string? DApres { get; set; }
    public string? Dialogue { get; set; }
    public string? Photo { get; set; }
    public string? Montage { get; set; }
    public string? Musique { get; set; }
    public string? AssistantRealisateur1 { get; set; }
    public string? AssistantRealisateur2 { get; set; }
    public string? AssistantRealisateur3 { get; set; }
    public string? Acteur1 { get; set; }
    public string? Acteur2 { get; set; }
    public string? Acteur3 { get; set; }
    public string? Acteur4 { get; set; }
    public string? Acteur5 { get; set; }
    public string? Acteur6 { get; set; }
    public string? Acteur7 { get; set; }
    public string? Acteur8 { get; set; }
    public string? Acteur9 { get; set; }
    public string? Acteur10 { get; set; }
    public string? Acteur11 { get; set; }
    public string? Acteur12 { get; set; }
    public string? Acteur13 { get; set; }
    public string? Acteur14 { get; set; }
    public string? Acteur15 { get; set; }
    public string? Acteur16 { get; set; }
    public string? Ou { get; set; } = string.Empty;
    public string Resume { get; set; } = string.Empty;
    public int Complet { get; set; }
    public int VerificationCD { get; set; }
    public string Dervision { get; set; } = string.Empty;
}
