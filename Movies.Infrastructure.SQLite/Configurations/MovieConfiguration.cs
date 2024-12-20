using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Movies.Domain.Models;

namespace Movies.Infrastructure.SQLite.Configurations;

internal sealed class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable("Movies");

        builder
            .HasKey(m => m.Id);

        builder
            .Property(m => m.Id)
            .ValueGeneratedOnAdd();
    }
}