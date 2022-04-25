namespace Dayconnect.Fidelity.Mediator.Handles;

public interface IMediatorHandler
{
    Task PublicarEvento<T>(T evento);
}