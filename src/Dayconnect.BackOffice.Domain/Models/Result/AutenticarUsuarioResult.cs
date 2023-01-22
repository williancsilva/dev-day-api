namespace DevSecOps.backoffice.Domain.Models.Result;

public class AutenticarUsuarioResult
{
    public bool Autenticado { get; private set; }
    public bool LoginHabilitado { get; private set; }

    public void AutenticarUsuario()
    {
        Autenticado = true;
        LoginHabilitado = true;
    }
}