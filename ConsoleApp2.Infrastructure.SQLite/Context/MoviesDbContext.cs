using ConsoleApp2.Domain.Models;
using ConsoleApp2.Infrastructure.SQLite.Configurations;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp2.Infrastructure.SQLite.Context;

internal sealed class MoviesDbContext : DbContext
{
    public MoviesDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<MovieType> Movies => Set<MovieType>();
    public DbSet<PersonType> Persons => Set<PersonType>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        new PersonConfiguration().Configure(modelBuilder.Entity<PersonType>());
        new MovieConfiguration().Configure(modelBuilder.Entity<MovieType>());
    }
}