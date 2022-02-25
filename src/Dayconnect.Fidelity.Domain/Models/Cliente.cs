namespace Dayconnect.Fidelity.Domain.Models;

public class Cliente
{
    public string Nome { get; }
    public string CpfCnpj { get; }
    public bool Ativo { get; }
    public bool IsValid { get; private set; }
        
    public Cliente(string nome, string cpfCnpj)
    {
        Nome = nome;
        CpfCnpj = cpfCnpj;
        Validar();
    }

    public Cliente(string nome, string cpfCnpj, bool ativo)
    {
        Nome = nome;
        CpfCnpj = cpfCnpj;
        Ativo = ativo;
        Validar();
    }

    private void Validar()
    {
        if (string.IsNullOrWhiteSpace(Nome))
            throw new ArgumentNullException("Nome obrigatório");

        if (string.IsNullOrWhiteSpace(CpfCnpj))
            throw new ArgumentNullException("Documento obrigatório");

        IsValid = true;
    }
}