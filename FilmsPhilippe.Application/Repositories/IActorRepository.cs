using FilmsPhilippe.Domain.Models;

namespace FilmsPhilippe.Application.Repositories;

public interface IActorRepository
{
	IEnumerable<Actor> List();
}
