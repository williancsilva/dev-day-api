namespace Dayconnect.backoffice.Mediator.Handles;

public interface IMediatorHandler
{
    Task PublicarEvento<T>(T evento);
}