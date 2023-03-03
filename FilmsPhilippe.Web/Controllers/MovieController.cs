using FilmsPhilippe.Application.UseCases.GetMovies;
using FilmsPhilippe.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmsPhilippe.Web.Controllers;

public class MovieController : Controller,
							   IGetMoviesOutputPort
{
	private readonly IGetMoviesUseCase _getMoviesUseCase;
	private readonly IConfiguration _configuration;

	private ActionResult? _result;
	private int _pageNumber;

	public MovieController(IGetMoviesUseCase getMoviesUseCase, IConfiguration configuration)
	{
		_getMoviesUseCase = getMoviesUseCase;
		_configuration = configuration;
	}

	public async Task<IActionResult> Index(string? searchString, int? pageNumber, string currentFilter)
	{
		_getMoviesUseCase.SetOutputPort(this);

		if (searchString != null)
		{
			_pageNumber = 1;
		}
		else
		{
			searchString = currentFilter;
			_pageNumber = pageNumber ?? 1;
		}

		await _getMoviesUseCase.ExecuteAsync(searchString);

		return _result!;
	}

	void IGetMoviesOutputPort.Ok(IEnumerable<Domain.Models.Movie> movie)
	{
		var movies = movie.Select(m => new Models.Movie
		{
			ReleaseDate = m.ReleaseDate,
			Title = m.Title,
			OriginalTitle = m.OriginalTitle
		});

		int pageSize = _configuration.GetValue<int>("PageSize");

		var model = new MovieViewModel()
		{
			Movies = PaginatedList<Models.Movie>.Create(movies.AsQueryable(), _pageNumber, pageSize)
		};

		_result = View(model);
	}
}
