using ConsoleApp2.Domain.Models;
using ConsoleApp2.Domain.Repositories;
using ConsoleApp2.Infrastructure.SQLite.Context;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp2.Infrastructure.SQLite.Repository;

internal sealed class MovieRepository : IMovieRepository
{
    private readonly MoviesDbContext _context;

    public MovieRepository(MoviesDbContext context)
    {
        _context = context;
        _context.Database.EnsureCreated();
    }

    public async Task<int> AddAsync(MovieType movie, CancellationToken token = default)
    {
        var entry = await _context.AddAsync(movie, token);
        await _context.SaveChangesAsync(token);
        return entry.Entity.Id;
    }

    public async Task AddRangeAsync(IEnumerable<MovieType> movies, CancellationToken token = default)
    {
        await _context.Movies.AddRangeAsync(movies, token);
        await  _context.SaveChangesAsync(token);
    }

    public async Task DeleteAsync(int id, CancellationToken token = default) =>
        await _context.Movies.Where(m => m.Id == id).ExecuteDeleteAsync(token);

    public IAsyncEnumerable<MovieType> GetAllAsync(CancellationToken token = default) =>
        _context.Movies.AsAsyncEnumerable();

    public async Task<MovieType?> GetAsync(int id, CancellationToken token = default) =>
        await _context.Movies.FindAsync([id], token);
}