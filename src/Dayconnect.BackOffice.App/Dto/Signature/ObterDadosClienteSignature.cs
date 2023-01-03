using DevSecOps.backoffice.App.Validators;
using Swashbuckle.AspNetCore.Annotations;

namespace DevSecOps.backoffice.App.Dto.Signature;

public class ObterDadosClienteSignature : DtoBase, IDtoContract
{
    [SwaggerSchema("Cpf/Cnpj do cliente a ser consultado", Nullable = false)]
    public string CpfCnpj { get; set; }

    public void ValidarDto()
    {
        Validar(this, new ObterDadosClienteValidator());
    }
}