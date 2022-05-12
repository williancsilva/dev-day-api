using Dayconnect.backoffice.Domain.Interfaces.Repository;
using Dayconnect.backoffice.Mediator.Adapters;
using Dayconnect.backoffice.Mediator.Notifications;
using MediatR;

namespace Dayconnect.backoffice.Mediator.Events;

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