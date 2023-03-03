using FilmsPhilippe.Application.Repositories;

namespace FilmsPhilippe.Application.UseCases.GetMovies;

internal class GetMoviesUseCase : IGetMoviesUseCase
{
    private readonly IMovieRepository _movieRepository;
    private IGetMoviesOutputPort? _outputPort;

    public GetMoviesUseCase(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public Task ExecuteAsync(string? searchString, CancellationToken token = default)
    {
        var movies = _movieRepository.List();

        if (!string.IsNullOrEmpty(searchString))
        {
            movies = movies.Where(s => s.Title != null && s.Title.Contains(searchString));
        }

        _outputPort?.Ok(movies);

        return Task.CompletedTask;
    }

    public void SetOutputPort(IGetMoviesOutputPort outputPort)
    {
        _outputPort = outputPort;
    }
}
