using Microsoft.EntityFrameworkCore;
using Movies.Domain;
using Movies.Infrastructure.SQLite.Configurations;

namespace Movies.Infrastructure.SQLite.Context;

internal sealed class MoviesDbContext : DbContext
{
    public MoviesDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Movie> Movies => base.Set<Movie>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        new MovieConfiguration().Configure(modelBuilder.Entity<Movie>());
    }
}
