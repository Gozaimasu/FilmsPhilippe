using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Movies.Domain.Models;

namespace Movies.Infrastructure.SQLite.Configurations;

internal sealed class DirectorConfiguration : IEntityTypeConfiguration<Director>
{
    public void Configure(EntityTypeBuilder<Director> builder)
    {
        builder.ToTable("Directors");

        builder
            .HasKey(d => d.Id);

        builder
            .Property(d => d.Id)
            .ValueGeneratedOnAdd();

        builder
            .HasMany(d => d.Movies)
            .WithMany(m => m.Directors);
    }
}