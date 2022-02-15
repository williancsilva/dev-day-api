using Dayconnect.Fidelity.Domain.Interfaces.Repository;
using Dayconnect.Fidelity.Mediator.Adapters;
using Dayconnect.Fidelity.Mediator.Notifications;
using MediatR;

namespace Dayconnect.Fidelity.Mediator.Events
{
    public class LogEventHandler : INotificationHandler<LogNotification>
    {
        private readonly ILogRepository _repository;

        public LogEventHandler(ILogRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(LogNotification notification, CancellationToken cancellationToken)
        {
            await _repository.InserirLog(notification.ConvertToDomain());
        }
    }
}
