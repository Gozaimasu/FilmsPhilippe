namespace FilmsPhilippe.Application.UseCases.GetMovies;

public interface IGetMoviesOutputPort
{
    void Ok(IEnumerable<Domain.Models.Movie> movie);
}
