namespace Dayconnect.Fidelity.Domain.Models
{
    public class LogDominio
    {
        public LogDominio(string cpfCnpjCliente, string metodo, string url, string loginOperador, string ip)
        {
            CpfCnpjCliente = cpfCnpjCliente;
            Metodo = metodo;
            Url = url;
            LoginOperador = loginOperador;
            Ip = ip;
            DataRegistro = DateTime.Now;
            Validar();
        }
        public string CpfCnpjCliente { get; }
        public string Metodo { get; }
        public string Url { get; }
        public string LoginOperador { get; }
        public DateTime DataRegistro { get; }
        public string Ip { get; }
        public bool IsValid { get; private set; }
        private void Validar()
        {
            if (string.IsNullOrWhiteSpace(Metodo))
                throw new ArgumentNullException("Metodo obrigatório");

            if (string.IsNullOrWhiteSpace(CpfCnpjCliente))
                throw new ArgumentNullException("Documento obrigatório");

            if (string.IsNullOrWhiteSpace(Url))
                throw new ArgumentNullException("Url obrigatório");

            if (string.IsNullOrWhiteSpace(LoginOperador))
                throw new ArgumentNullException("LoginOperador obrigatório");

            if (string.IsNullOrWhiteSpace(Ip))
                throw new ArgumentNullException("Ip obrigatório");

            if (DataRegistro == DateTime.MinValue)
                throw new ArgumentException("Data do Registro Invalida");

            IsValid = true;
        }
    }
}
