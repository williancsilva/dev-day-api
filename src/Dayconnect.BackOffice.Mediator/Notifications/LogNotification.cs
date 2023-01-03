using MediatR;

namespace DevSecOps.backoffice.Mediator.Notifications;

public class LogNotification : INotification
{
    public string cpfCnpjCliente { get; }
    public string Metodo { get; }
    public string Url { get; }
    public string LoginOperador { get; }
    public DateTime DataRegistro { get; }
    public string Ip { get; }

    public LogNotification(string cpfCnpjCliente, string metodo, string url, string loginOperador, string ip)
    {
        this.cpfCnpjCliente = cpfCnpjCliente;
        Metodo = metodo;
        Url = url;
        LoginOperador = loginOperador;
        Ip = ip;
        DataRegistro = DateTime.Now;
    }
}