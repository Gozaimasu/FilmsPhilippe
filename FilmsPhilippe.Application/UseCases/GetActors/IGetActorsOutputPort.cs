using FilmsPhilippe.Domain.Models;

namespace FilmsPhilippe.Application.UseCases.GetActors;

public interface IGetActorsOutputPort
{
	void Ok(IEnumerable<Actor> movie);
}
