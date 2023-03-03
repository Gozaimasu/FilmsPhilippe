namespace FilmsPhilippe.Application.UseCases.GetMovies;

public interface IGetMoviesUseCase
{
    Task ExecuteAsync(string? searchString, CancellationToken token = default);
    void SetOutputPort(IGetMoviesOutputPort outputPort);
}
