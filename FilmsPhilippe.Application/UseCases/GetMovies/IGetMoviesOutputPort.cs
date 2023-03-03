using FilmsPhilippe.Domain.Models;

namespace FilmsPhilippe.Application.UseCases.GetMovies;

public interface IGetMoviesOutputPort
{
    void Ok(IEnumerable<Movie> movie);
}
