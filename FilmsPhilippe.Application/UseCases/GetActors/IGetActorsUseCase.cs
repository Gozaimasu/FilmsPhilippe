namespace FilmsPhilippe.Application.UseCases.GetActors;

public interface IGetActorsUseCase
{
	Task ExecuteAsync(string? searchString, CancellationToken token = default);
	void SetOutputPort(IGetActorsOutputPort outputPort);
}
