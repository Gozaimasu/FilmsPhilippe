namespace FilmsPhilippe.Application.Repositories;

public interface IMovieRepository
{
    IEnumerable<Domain.Models.Movie> List();
}
