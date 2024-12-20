using ConsoleApp2.Domain.Models;
using ConsoleApp2.Domain.Processes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp2.Infrastructure.SQLite.Configurations;

internal sealed class PersonConfiguration : IEntityTypeConfiguration<PersonType>
{
    public void Configure(EntityTypeBuilder<PersonType> builder)
    {
        builder.ToTable("Persons");

        builder
            .HasKey(a => a.Id);

        builder
            .Property(a => a.Id)
            .ValueGeneratedOnAdd();

        builder
            .Property(a => a.Name)
            .HasConversion(
                n => FormatNameDefaults.FormatFullName.Invoke(n),
                n => Name.Create(n)!);

        builder
            .HasMany(p => p.MoviesAsActor)
            .WithMany(m => m.Actors)
            .UsingEntity(
                "ActorMovie",
                r => r.HasOne(typeof(MovieType)).WithMany().HasForeignKey("MovieId").HasPrincipalKey(nameof(MovieType.Id)),
                l => l.HasOne(typeof(PersonType)).WithMany().HasForeignKey("PersonId").HasPrincipalKey(nameof(PersonType.Id)),
                j => j.HasKey("MovieId", "PersonId"));

        builder
            .HasMany(p => p.MoviesAsDirector)
            .WithMany(m => m.Directors)
            .UsingEntity(
                "DirectorMovie",
                r => r.HasOne(typeof(MovieType)).WithMany().HasForeignKey("MovieId").HasPrincipalKey(nameof(MovieType.Id)),
                l => l.HasOne(typeof(PersonType)).WithMany().HasForeignKey("PersonId").HasPrincipalKey(nameof(PersonType.Id)),
                j => j.HasKey("MovieId", "PersonId"));

        builder
            .HasMany(p => p.MoviesAsScriptWriter)
            .WithMany(m => m.ScriptWriters)
            .UsingEntity(
                "ScriptWriterMovie",
                r => r.HasOne(typeof(MovieType)).WithMany().HasForeignKey("MovieId").HasPrincipalKey(nameof(MovieType.Id)),
                l => l.HasOne(typeof(PersonType)).WithMany().HasForeignKey("PersonId").HasPrincipalKey(nameof(PersonType.Id)),
                j => j.HasKey("MovieId", "PersonId"));

        builder
            .HasMany(p => p.MoviesAsAssistantDirector)
            .WithMany(m => m.AssistantDirectors)
            .UsingEntity(
                "AssistantDirectorMovie",
                r => r.HasOne(typeof(MovieType)).WithMany().HasForeignKey("MovieId").HasPrincipalKey(nameof(MovieType.Id)),
                l => l.HasOne(typeof(PersonType)).WithMany().HasForeignKey("PersonId").HasPrincipalKey(nameof(PersonType.Id)),
                j => j.HasKey("MovieId", "PersonId"));

        builder
            .HasMany(p => p.MoviesAsOriginalWriter)
            .WithMany(m => m.OriginalWriters)
            .UsingEntity(
                "OriginalWriterMovie",
                r => r.HasOne(typeof(MovieType)).WithMany().HasForeignKey("MovieId").HasPrincipalKey(nameof(MovieType.Id)),
                l => l.HasOne(typeof(PersonType)).WithMany().HasForeignKey("PersonId").HasPrincipalKey(nameof(PersonType.Id)),
                j => j.HasKey("MovieId", "PersonId"));

        builder
            .HasMany(p => p.MoviesAsPhotographer)
            .WithMany(m => m.Photographers)
            .UsingEntity(
                "PhotographerMovie",
                r => r.HasOne(typeof(MovieType)).WithMany().HasForeignKey("MovieId").HasPrincipalKey(nameof(MovieType.Id)),
                l => l.HasOne(typeof(PersonType)).WithMany().HasForeignKey("PersonId").HasPrincipalKey(nameof(PersonType.Id)),
                j => j.HasKey("MovieId", "PersonId"));

        builder
            .HasMany(p => p.MoviesAsDialogueWriter)
            .WithMany(m => m.DialogueWriters)
            .UsingEntity(
                "DialogueWriterMovie",
                r => r.HasOne(typeof(MovieType)).WithMany().HasForeignKey("MovieId").HasPrincipalKey(nameof(MovieType.Id)),
                l => l.HasOne(typeof(PersonType)).WithMany().HasForeignKey("PersonId").HasPrincipalKey(nameof(PersonType.Id)),
                j => j.HasKey("MovieId", "PersonId"));

        builder
            .HasMany(p => p.MoviesAsEditing)
            .WithMany(m => m.Editing)
            .UsingEntity(
                "EditingMovie",
                r => r.HasOne(typeof(MovieType)).WithMany().HasForeignKey("MovieId").HasPrincipalKey(nameof(MovieType.Id)),
                l => l.HasOne(typeof(PersonType)).WithMany().HasForeignKey("PersonId").HasPrincipalKey(nameof(PersonType.Id)),
                j => j.HasKey("MovieId", "PersonId"));

        builder
            .HasMany(p => p.MoviesAsMusic)
            .WithMany(m => m.Music)
            .UsingEntity(
                "MusicMovie",
                r => r.HasOne(typeof(MovieType)).WithMany().HasForeignKey("MovieId").HasPrincipalKey(nameof(MovieType.Id)),
                l => l.HasOne(typeof(PersonType)).WithMany().HasForeignKey("PersonId").HasPrincipalKey(nameof(PersonType.Id)),
                j => j.HasKey("MovieId", "PersonId"));
    }
}