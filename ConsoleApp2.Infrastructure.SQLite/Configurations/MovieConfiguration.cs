using ConsoleApp2.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp2.Infrastructure.SQLite.Configurations;

internal sealed class MovieConfiguration : IEntityTypeConfiguration<MovieType>
{
    public void Configure(EntityTypeBuilder<MovieType> builder)
    {
        builder.ToTable("Movies");

        builder
            .HasKey(m => m.Id);

        builder
            .Property(m => m.Id)
            .ValueGeneratedOnAdd();

        // builder
        //     .HasMany(m => m.Actors)
        //     .WithMany(m => m.Movies)
        //     .UsingEntity(
        //         "ActorMovie",
        //         l => l.HasOne(typeof(PersonType)).WithMany().HasForeignKey("PersonId").HasPrincipalKey(nameof(PersonType.Id)),
        //         r => r.HasOne(typeof(MovieType)).WithMany().HasForeignKey("MovieId").HasPrincipalKey(nameof(MovieType.Id)),
        //         j => j.HasKey("MovieId", "PersonId"));
        
        // builder
        //     .HasMany(m => m.Directors)
        //     .WithMany(m => m.Movies)
        //     .UsingEntity(
        //         "DirectorMovie",
        //         l => l.HasOne(typeof(PersonType)).WithMany().HasForeignKey("PersonId").HasPrincipalKey(nameof(PersonType.Id)),
        //         r => r.HasOne(typeof(MovieType)).WithMany().HasForeignKey("MovieId").HasPrincipalKey(nameof(MovieType.Id)),
        //         j => j.HasKey("MovieId", "PersonId"));
        //
        // builder
        //     .HasMany(m => m.ScriptWriters)
        //     .WithMany(m => m.Movies)
        //     .UsingEntity(
        //         "ScriptWriterMovie",
        //         l => l.HasOne(typeof(PersonType)).WithMany().HasForeignKey("PersonId").HasPrincipalKey(nameof(PersonType.Id)),
        //         r => r.HasOne(typeof(MovieType)).WithMany().HasForeignKey("MovieId").HasPrincipalKey(nameof(MovieType.Id)),
        //         j => j.HasKey("MovieId", "PersonId"));
        //
        // builder
        //     .HasMany(m => m.AssistantDirectors)
        //     .WithMany(m => m.Movies)
        //     .UsingEntity(
        //         "AssistantDirectorMovie",
        //         l => l.HasOne(typeof(PersonType)).WithMany().HasForeignKey("PersonId").HasPrincipalKey(nameof(PersonType.Id)),
        //         r => r.HasOne(typeof(MovieType)).WithMany().HasForeignKey("MovieId").HasPrincipalKey(nameof(MovieType.Id)),
        //         j => j.HasKey("MovieId", "PersonId"));
        //
        // builder
        //     .HasMany(m => m.OriginalWriters)
        //     .WithMany(m => m.Movies)
        //     .UsingEntity(
        //         "OriginalWriterMovie",
        //         l => l.HasOne(typeof(PersonType)).WithMany().HasForeignKey("PersonId").HasPrincipalKey(nameof(PersonType.Id)),
        //         r => r.HasOne(typeof(MovieType)).WithMany().HasForeignKey("MovieId").HasPrincipalKey(nameof(MovieType.Id)),
        //         j => j.HasKey("MovieId", "PersonId"));
        //
        // builder
        //     .HasMany(m => m.Photographers)
        //     .WithMany(m => m.Movies)
        //     .UsingEntity(
        //         "PhotographerMovie",
        //         l => l.HasOne(typeof(PersonType)).WithMany().HasForeignKey("PersonId").HasPrincipalKey(nameof(PersonType.Id)),
        //         r => r.HasOne(typeof(MovieType)).WithMany().HasForeignKey("MovieId").HasPrincipalKey(nameof(MovieType.Id)),
        //         j => j.HasKey("MovieId", "PersonId"));
        //
        // builder
        //     .HasMany(m => m.DialogueWriters)
        //     .WithMany(m => m.Movies)
        //     .UsingEntity(
        //         "DialogueWriterMovie",
        //         l => l.HasOne(typeof(PersonType)).WithMany().HasForeignKey("PersonId").HasPrincipalKey(nameof(PersonType.Id)),
        //         r => r.HasOne(typeof(MovieType)).WithMany().HasForeignKey("MovieId").HasPrincipalKey(nameof(MovieType.Id)),
        //         j => j.HasKey("MovieId", "PersonId"));
        //
        // builder
        //     .HasMany(m => m.Editing)
        //     .WithMany(m => m.Movies)
        //     .UsingEntity(
        //         "EditingMovie",
        //         l => l.HasOne(typeof(PersonType)).WithMany().HasForeignKey("PersonId").HasPrincipalKey(nameof(PersonType.Id)),
        //         r => r.HasOne(typeof(MovieType)).WithMany().HasForeignKey("MovieId").HasPrincipalKey(nameof(MovieType.Id)),
        //         j => j.HasKey("MovieId", "PersonId"));
        //
        // builder
        //     .HasMany(m => m.Music)
        //     .WithMany(m => m.Movies)
        //     .UsingEntity(
        //         "MusicMovie",
        //         l => l.HasOne(typeof(PersonType)).WithMany().HasForeignKey("PersonId").HasPrincipalKey(nameof(PersonType.Id)),
        //         r => r.HasOne(typeof(MovieType)).WithMany().HasForeignKey("MovieId").HasPrincipalKey(nameof(MovieType.Id)),
        //         j => j.HasKey("MovieId", "PersonId"));
        
        builder
            .Property(a => a.Title)
            .HasConversion(
                t => t.Value,
                t => Title.Create(t)!);
        
        builder
            .Property(a => a.Year)
            .HasConversion(
                y => y.Value,
                y => Year.Create(y)!);
        
        builder
            .Property(a => a.Origin)
            .HasConversion(
                c => c.Name,
                c => Country.Create(c)!);
        
        builder
            .Property(m => m.OriginalTitle)
            .HasConversion(
                ot => ot.Value,
                ot => Title.Create(ot)!);

        builder
            .Ignore(m => m.Actors)
            .Ignore(m => m.Directors)
            .Ignore(m => m.ScriptWriters)
            .Ignore(m => m.AssistantDirectors)
            .Ignore(m => m.OriginalWriters)
            .Ignore(m => m.Photographers)
            .Ignore(m => m.DialogueWriters)
            .Ignore(m => m.Editing)
            .Ignore(m => m.Music);
    }
}