using FilmsPhilippe.Domain.Models;

namespace FilmsPhilippe.Application.Repositories;

public interface IMovieRepository
{
    IEnumerable<Movie> List();
}
