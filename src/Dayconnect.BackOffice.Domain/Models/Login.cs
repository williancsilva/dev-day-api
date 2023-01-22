namespace DevSecOps.backoffice.Domain.Models;

public class Login
{
    public int Id { get; }
    public bool? Autenticado { get; }
    public bool? Habilitado { get; }
    public bool Logado => Autenticado.HasValue && Habilitado.HasValue && Autenticado.Value && Habilitado.Value;
    public bool IsValid { get; private set; }

    public Login(int id, bool? autenticado, bool? habilitado)
    {
        Id = id;
        Autenticado = autenticado;
        Habilitado = habilitado;
        Validar();
    }

    private void Validar()
    {
        if (Id <= 0)
            throw new ArgumentNullException(Id.ToString(), "Id obrigatório");

        IsValid = true;
    }
}