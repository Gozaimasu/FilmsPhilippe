using ConsoleApp2.Domain.Models;

namespace ConsoleApp2.Domain.Repositories;

public interface IMovieRepository
{
    Task<int> AddAsync(MovieType movie, CancellationToken token = default);
    Task AddRangeAsync(IEnumerable<MovieType> movies, CancellationToken token = default);
    Task DeleteAsync(int id, CancellationToken token = default);
    IAsyncEnumerable<MovieType> GetAllAsync(CancellationToken token = default);
    Task<MovieType?> GetAsync(int id, CancellationToken token = default);
}