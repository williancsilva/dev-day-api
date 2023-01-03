using DevSecOps.backoffice.Domain.Interfaces.Repository;
using DevSecOps.backoffice.Mediator.Adapters;
using DevSecOps.backoffice.Mediator.Notifications;
using MediatR;

namespace DevSecOps.backoffice.Mediator.Events;

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