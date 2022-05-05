namespace Dayconnect.Fidelity.Domain.Models;

public class LogDominio
{
    public string cpfCnpjCliente { get; }
    public string Metodo { get; }
    public string Url { get; }
    public string LoginOperador { get; }
    public DateTime DataRegistro { get; }
    public string Ip { get; }
    public bool IsValid { get; private set; }

    public LogDominio(string cpfCnpjCliente, string metodo, string url, string loginOperador, string ip)
    {
        this.cpfCnpjCliente = cpfCnpjCliente;
        Metodo = metodo;
        Url = url;
        LoginOperador = loginOperador;
        Ip = ip;
        DataRegistro = DateTime.Now;
        Validar();
    }

    private void Validar()
    {
        if (string.IsNullOrWhiteSpace(Metodo))
            throw new ArgumentNullException(Metodo, "Metodo obrigatório");

        if (string.IsNullOrWhiteSpace(cpfCnpjCliente))
            throw new ArgumentNullException(cpfCnpjCliente, "Documento obrigatório");

        if (string.IsNullOrWhiteSpace(Url))
            throw new ArgumentNullException(Url, "Url obrigatório");

        if (string.IsNullOrWhiteSpace(LoginOperador))
            throw new ArgumentNullException(LoginOperador, "LoginOperador obrigatório");

        if (string.IsNullOrWhiteSpace(Ip))
            throw new ArgumentNullException(Ip, "Ip obrigatório");

        if (DataRegistro == DateTime.MinValue)
            throw new ArgumentException("Data do Registro Invalida");

        IsValid = true;
    }
}