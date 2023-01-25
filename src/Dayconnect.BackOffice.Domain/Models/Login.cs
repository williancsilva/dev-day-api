using DevSecOps.backoffice.Domain.Models.Result;

namespace DevSecOps.backoffice.Domain.Models;

public class Login
{
    public int Id { get; }
    public bool? Autenticado { get; }
    public bool? Habilitado { get; }
    public string Senha { get; set; }
    public bool Logado => Autenticado.HasValue && Habilitado.HasValue && Autenticado.Value && Habilitado.Value;
    public bool IsValid { get; private set; }
    public Permission Permissoes { get; set; }

    public Login(int id, bool? autenticado, bool? habilitado, Permission? permissoes, string senha)
    {
        Id = id;
        Autenticado = autenticado;
        Habilitado = habilitado;
        Validar();
        Permissoes = permissoes;
        Senha = senha;
    }

    private void Validar()
    {
        if (Id <= 0)
            throw new ArgumentNullException(Id.ToString(), "Id obrigatório");

        IsValid = true;
    }
}