using FilmsPhilippe.Application.Repositories;

namespace FilmsPhilippe.Application.UseCases.GetActors;

internal class GetActorsUseCase : IGetActorsUseCase
{
    private readonly IActorRepository _actorRepository;
    private IGetActorsOutputPort? _outputPort;

    public GetActorsUseCase(IActorRepository actorRepository)
    {
        _actorRepository = actorRepository;
    }

    public Task ExecuteAsync(string? searchString, CancellationToken token = default)
    {
        var actors = _actorRepository.List();

        if (!string.IsNullOrEmpty(searchString))
        {
            actors = actors.Where(s => s.Name != null && s.Name.Contains(searchString));
        }

        _outputPort?.Ok(actors);

        return Task.CompletedTask;
    }

    public void SetOutputPort(IGetActorsOutputPort outputPort)
    {
        _outputPort = outputPort;
    }
}
