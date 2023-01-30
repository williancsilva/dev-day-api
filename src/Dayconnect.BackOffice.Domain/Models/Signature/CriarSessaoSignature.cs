namespace DevSecOps.backoffice.Domain.Models.Signature;

public class CriarSessaoSignature
{
    public int CodSistema => 439;
    public int CodTipoDispositivo => 1;
    public int Expiration => 999;
    public string Login { get; }
    public string IpUsuario { get; }
    public string DeviceId { get; }
    public string VersaoDispositivo { get; }
    public bool IsValid { get; private set; }

    public CriarSessaoSignature(string login, string ip, string deviceId, string versaoDispositivo)
    {
        Login = login;
        IpUsuario = ip;
        DeviceId = deviceId;
        VersaoDispositivo = versaoDispositivo;
        Validar();
    }

    private void Validar()
    {
        if (string.IsNullOrWhiteSpace(Login))
            throw new ArgumentNullException(Login, "Login obrigatório");

        if (string.IsNullOrWhiteSpace(IpUsuario))
            throw new ArgumentNullException(IpUsuario, "IpUsuario obrigatório");

        if (string.IsNullOrWhiteSpace(DeviceId))
            throw new ArgumentNullException(DeviceId, "DeviceId obrigatório");

        if (string.IsNullOrWhiteSpace(VersaoDispositivo))
            throw new ArgumentNullException(VersaoDispositivo, "VersaoDispositivo obrigatório");

        IsValid = true;
    }
}