using DevSecOps.backoffice.App.Validators;
using Swashbuckle.AspNetCore.Annotations;

namespace DevSecOps.backoffice.App.Dto.Signature;

public class AtivarClienteSignature : DtoBase, IDtoContract
{
    [SwaggerSchema("Cpf/Cnpj do cliente a ser ativado", Nullable = false)]
    public string CpfCnpj { get; set; }


    public void ValidarDto()
    {
        Validar(this, new AtivarClienteValidator());
    }
}

