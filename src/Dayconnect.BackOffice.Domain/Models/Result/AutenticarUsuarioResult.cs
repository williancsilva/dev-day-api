namespace DevSecOps.backoffice.Domain.Models.Result;

public class AutenticarUsuarioResult
{
    public bool Autenticado { get; private set; }
    public bool LoginHabilitado { get; private set; }
    public Permission? Permissoes { get; private set; }

    public void AutenticarUsuario(Permission permissoes)
    {
        Autenticado = true;
        LoginHabilitado = true;
        Permissoes = permissoes;
    }
}