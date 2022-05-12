using MediatR;

namespace Dayconnect.backoffice.Mediator.Handles;

public class MediatorHandler : IMediatorHandler
{
    private readonly IMediator _mediator;

    public MediatorHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task PublicarEvento<T>(T? evento)
    {
        if (evento != null) await _mediator.Publish(evento);
    }
}