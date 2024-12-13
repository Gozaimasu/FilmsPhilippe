using FilmsPhilippe.Application.UseCases.GetActors;
using FilmsPhilippe.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmsPhilippe.Web.Controllers
{
    public class ActorController : Controller, IGetActorsOutputPort
    {
        private readonly IGetActorsUseCase _getActorsUseCase;
        private readonly IConfiguration _configuration;

        private ActionResult? _result;
        private int _pageNumber;

        public ActorController(IGetActorsUseCase getActorsUseCase, IConfiguration configuration)
        {
            _getActorsUseCase = getActorsUseCase;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index(string? searchString, int? pageNumber, string currentFilter)
        {
            _getActorsUseCase.SetOutputPort(this);

            if (searchString != null)
            {
                _pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
                _pageNumber = pageNumber ?? 1;
            }

            await _getActorsUseCase.ExecuteAsync(searchString);

            return _result!;
        }

        void IGetActorsOutputPort.Ok(IEnumerable<Domain.Models.Actor> actor)
        {
            var actors = actor.Select(m => new Actor
            {
                Name = m.Name
            });

            int pageSize = _configuration.GetValue<int>("PageSize");

            var model = new ActorViewModel()
            {
                Actors = PaginatedList<Actor>.Create(actors.AsQueryable(), _pageNumber, pageSize)
            };

            _result = View(model);
        }
    }
}
