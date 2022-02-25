using MediatR;

namespace Dayconnect.Fidelity.Mediator.Notifications;

public class LogNotification : INotification
{
    public string CpfCnpjCliente { get; }
    public string Metodo { get; }
    public string Url { get; }
    public string LoginOperador { get; }
    public DateTime DataRegistro { get; }
    public string Ip { get; }

    public LogNotification(string cpfCnpjCliente, string metodo, string url, string loginOperador, string ip)
    {
        CpfCnpjCliente = cpfCnpjCliente;
        Metodo = metodo;
        Url = url;
        LoginOperador = loginOperador;
        Ip = ip;
        DataRegistro = DateTime.Now;
    }
}