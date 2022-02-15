using Dayconnect.Fidelity.App.Validators;
using Swashbuckle.AspNetCore.Annotations;

namespace Dayconnect.Fidelity.App.Dto.Signature
{
    public class InativarClienteSignature : DtoBase, IDtoContract
    {
        [SwaggerSchema("Cpf/Cnpj do cliente a ser bloqueado", Nullable = false)]
        public string CpfCnpj { get; set; }
        public void ValidarDto()
        {
            Validar(this, new InativarClienteValidator());
        }
    }
}
