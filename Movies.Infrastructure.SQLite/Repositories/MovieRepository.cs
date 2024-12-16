using Microsoft.EntityFrameworkCore;
using Movies.Domain.Models;
using Movies.Domain.Repositories;
using Movies.Infrastructure.SQLite.Context;

namespace Movies.Infrastructure.SQLite.Repositories;

internal sealed class MovieRepository : IMovieRepository
{
    private readonly MoviesDbContext _context;

    public MovieRepository(MoviesDbContext context)
    {
        _context = context;
        _context.Database.EnsureCreated();
    }

    public async Task<Guid> AddAsync(Movie movie, CancellationToken token = default)
    {
        var entry = await _context.AddAsync(movie, token);
        await _context.SaveChangesAsync(token);
        return entry.Entity.Id;
    }

    public async Task DeleteAsync(Guid id, CancellationToken token = default) =>
        await _context.Movies.Where(m => m.Id.Equals(id)).ExecuteDeleteAsync(token);

    public async Task<IEnumerable<Movie>> GetAllAsync(CancellationToken token = default) =>
        await _context.Movies.Take(100).ToListAsync(token);

    public async Task<Movie?> GetAsync(Guid id, CancellationToken token = default) =>
        await _context.Movies.FindAsync([id], token);
}
