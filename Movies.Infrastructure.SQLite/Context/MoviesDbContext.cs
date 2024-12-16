using Microsoft.EntityFrameworkCore;
using Movies.Domain.Models;
using Movies.Infrastructure.SQLite.Configurations;

namespace Movies.Infrastructure.SQLite.Context;

internal sealed class MoviesDbContext : DbContext
{
    public MoviesDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Movie> Movies => base.Set<Movie>();
    public DbSet<Actor> Actors => base.Set<Actor>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        new MovieConfiguration().Configure(modelBuilder.Entity<Movie>());
        new ActorConfiguration().Configure(modelBuilder.Entity<Actor>());
    }
}
