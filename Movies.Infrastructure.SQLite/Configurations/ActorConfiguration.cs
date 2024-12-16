using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Movies.Domain.Models;

namespace Movies.Infrastructure.SQLite.Configurations;

internal sealed class ActorConfiguration : IEntityTypeConfiguration<Actor>
{
    public void Configure(EntityTypeBuilder<Actor> builder)
    {
        builder.ToTable("Actors");

        builder
            .HasKey(x => x.Id);

        builder
            .Property(m => m.Id)
            .ValueGeneratedOnAdd();

        builder
            .HasMany(a => a.Movies)
            .WithMany(m => m.Actors);
    }
}