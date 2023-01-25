namespace DevSecOps.backoffice.Domain.Models.Result;

public class AutenticarUsuarioResult
{
    public bool Autenticado { get; private set; }
    public bool LoginHabilitado { get; private set; }
    public string Senha { get; set; }
    public Permission? Permissoes { get; private set; }

    public void AutenticarUsuario(SessaoResult sessao)
    {
        Autenticado = true;
        LoginHabilitado = true;
        Permissoes = sessao.Permission;
        Senha = sessao.Senha;
    }
}