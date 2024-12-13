using Microsoft.EntityFrameworkCore;

namespace MsAccessToSQLite;

internal class MoviesDbContext : DbContext
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