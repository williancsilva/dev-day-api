namespace Dayconnect.Fidelity.Domain.Models.Signature
{
    public class CriarSessaoSignature
    {
        public CriarSessaoSignature(string login, string ip, string deviceId, string versaoDispositivo)
        {
            Login = login;
            IpUsuario = ip;
            DeviceId = deviceId;
            VersaoDispositivo = versaoDispositivo;
            Validar();
        }

        public int CodSistema => 353;
        public int CodTipoDispositivo => 1;
        public int Expiration => 20;
        public string Login { get; }
        public string IpUsuario { get; }
        public string DeviceId { get; }
        public string VersaoDispositivo { get; }
        public bool IsValid { get; private set; }
        private void Validar()
        {
            if (string.IsNullOrWhiteSpace(Login))
                throw new ArgumentNullException("Login obrigatório");

            if (string.IsNullOrWhiteSpace(IpUsuario))
                throw new ArgumentNullException("IpUsuario obrigatório");

            if (string.IsNullOrWhiteSpace(DeviceId))
                throw new ArgumentNullException("DeviceId obrigatório");

            if (string.IsNullOrWhiteSpace(VersaoDispositivo))
                throw new ArgumentNullException("VersaoDispositivo obrigatório");

            IsValid = true;
        }
    }
}
