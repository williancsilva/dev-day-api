using MediatR;

namespace Dayconnect.Fidelity.Mediator.Handles
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task PublicarEvento<T>(T evento)
        {
            await _mediator.Publish(evento);
        }
    }
}
