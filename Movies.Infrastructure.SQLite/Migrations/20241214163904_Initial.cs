using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movies.Infrastructure.SQLite.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Titre = table.Column<string>(type: "TEXT", nullable: false),
                    TitreOriginal = table.Column<string>(type: "TEXT", nullable: true),
                    Annee = table.Column<int>(type: "INTEGER", nullable: false),
                    Origine = table.Column<string>(type: "TEXT", nullable: false),
                    Minutage = table.Column<int>(type: "INTEGER", nullable: false),
                    Vision = table.Column<int>(type: "INTEGER", nullable: false),
                    Qui = table.Column<string>(type: "TEXT", nullable: false),
                    Realisateur1 = table.Column<string>(type: "TEXT", nullable: true),
                    Realisateur2 = table.Column<string>(type: "TEXT", nullable: true),
                    Scenario = table.Column<string>(type: "TEXT", nullable: true),
                    Scenario1 = table.Column<string>(type: "TEXT", nullable: true),
                    DApres = table.Column<string>(type: "TEXT", nullable: true),
                    Dialogue = table.Column<string>(type: "TEXT", nullable: true),
                    Photo = table.Column<string>(type: "TEXT", nullable: true),
                    Montage = table.Column<string>(type: "TEXT", nullable: true),
                    Musique = table.Column<string>(type: "TEXT", nullable: true),
                    AssistantRealisateur1 = table.Column<string>(type: "TEXT", nullable: true),
                    AssistantRealisateur2 = table.Column<string>(type: "TEXT", nullable: true),
                    AssistantRealisateur3 = table.Column<string>(type: "TEXT", nullable: true),
                    Acteur1 = table.Column<string>(type: "TEXT", nullable: true),
                    Acteur2 = table.Column<string>(type: "TEXT", nullable: true),
                    Acteur3 = table.Column<string>(type: "TEXT", nullable: true),
                    Acteur4 = table.Column<string>(type: "TEXT", nullable: true),
                    Acteur5 = table.Column<string>(type: "TEXT", nullable: true),
                    Acteur6 = table.Column<string>(type: "TEXT", nullable: true),
                    Acteur7 = table.Column<string>(type: "TEXT", nullable: true),
                    Acteur8 = table.Column<string>(type: "TEXT", nullable: true),
                    Acteur9 = table.Column<string>(type: "TEXT", nullable: true),
                    Acteur10 = table.Column<string>(type: "TEXT", nullable: true),
                    Acteur11 = table.Column<string>(type: "TEXT", nullable: true),
                    Acteur12 = table.Column<string>(type: "TEXT", nullable: true),
                    Acteur13 = table.Column<string>(type: "TEXT", nullable: true),
                    Acteur14 = table.Column<string>(type: "TEXT", nullable: true),
                    Acteur15 = table.Column<string>(type: "TEXT", nullable: true),
                    Acteur16 = table.Column<string>(type: "TEXT", nullable: true),
                    Ou = table.Column<string>(type: "TEXT", nullable: true),
                    Resume = table.Column<string>(type: "TEXT", nullable: false),
                    Complet = table.Column<int>(type: "INTEGER", nullable: false),
                    VerificationCD = table.Column<int>(type: "INTEGER", nullable: false),
                    Dervision = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
