namespace Dayconnect.Fidelity.Domain.Models
{
    public class Login
    {
        public Login(string id, bool? autenticado, bool? habilitado)
        {
            Id = id;
            Autenticado = autenticado;
            Habilitado = habilitado;
            Validar();
        }

        public string Id { get; }
        public bool? Autenticado { get; }
        public bool? Habilitado { get; }
        public bool Logado => (Autenticado.HasValue && Habilitado.HasValue) && (Autenticado.Value && Habilitado.Value);
        public bool IsValid { get; private set; }
        private void Validar()
        {
            if (string.IsNullOrWhiteSpace(Id))
                throw new ArgumentNullException("Id obrigatório");

            IsValid = true;
        }
    }
}
