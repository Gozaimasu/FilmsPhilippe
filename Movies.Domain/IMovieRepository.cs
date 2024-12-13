namespace Movies.Domain;

public interface IMovieRepository
{
    Task<Guid> AddAsync(Movie movie, CancellationToken token = default);
    Task DeleteAsync(Guid id, CancellationToken token = default);
    Task<IEnumerable<Movie>> GetAllAsync(CancellationToken token = default);
    Task<Movie?> GetAsync(Guid id, CancellationToken token = default);
}
