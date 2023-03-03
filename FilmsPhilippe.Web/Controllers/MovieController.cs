using FilmsPhilippe.Application.UseCases.GetMovies;
using FilmsPhilippe.Domain.Models;
using FilmsPhilippe.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmsPhilippe.Web.Controllers;

public class MovieController : Controller,
                               IGetMoviesOutputPort 
{
    private readonly IGetMoviesUseCase _getMoviesUseCase;

    private ActionResult? _result;

    public MovieController(IGetMoviesUseCase getMoviesUseCase)
    {
        _getMoviesUseCase = getMoviesUseCase;
    }

    public async Task<IActionResult> Index(string? searchString)
    {
        _getMoviesUseCase.SetOutputPort(this);

        await _getMoviesUseCase.ExecuteAsync(searchString);

        return _result!;
    }

    void IGetMoviesOutputPort.Ok(IEnumerable<Domain.Models.Movie> movie)
    {
        var model = new MovieViewModel()
        {
            Movies = movie.Select(m => new Models.Movie
            {
                ReleaseDate = m.ReleaseDate,
                Title = m.Title,
                OriginalTitle = m.OriginalTitle
            }).ToList()
        };
        _result = View(model);
    }
}
