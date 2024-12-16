using Movies.Domain.Models;

namespace Movies.Domain.Repositories;

public interface IMovieRepository
{
    Task<int> AddAsync(Movie movie, CancellationToken token = default);
    Task AddRangeAsync(IEnumerable<Movie> movies, CancellationToken token = default);
    Task DeleteAsync(int id, CancellationToken token = default);
    Task<IEnumerable<Movie>> GetAllAsync(CancellationToken token = default);
    Task<Movie?> GetAsync(int id, CancellationToken token = default);
}
