using System;

namespace Dayconnect.Fidelity.Domain.Models
{
    public class Cliente
    {
        public Cliente(string nome, string cpfCnpj)
        {
            Nome = nome;
            CpfCnpj = cpfCnpj;
            Validar();
        }

        public string Nome { get; }
        public string CpfCnpj { get; }
        public bool Ativo { get; private set; }
        public bool IsValid { get; private set; }
        private void Validar()
        {
            if (string.IsNullOrWhiteSpace(Nome))
                throw new ArgumentNullException("Nome obrigatório");

            if (string.IsNullOrWhiteSpace(CpfCnpj))
                throw new ArgumentNullException("Documento obrigatório");

            IsValid = true;
        }

        public void SetAtivo(bool _ativo)
        {
            Ativo = _ativo;
        }
    }
}
