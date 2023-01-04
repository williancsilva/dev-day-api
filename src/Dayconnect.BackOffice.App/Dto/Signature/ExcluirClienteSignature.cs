using DevSecOps.backoffice.App.Validators;
using Swashbuckle.AspNetCore.Annotations;

namespace DevSecOps.backoffice.App.Dto.Signature;

public class ExcluirClienteSignature : DtoBase
{
    [SwaggerSchema("Cpf/Cnpj do cliente a ser bloqueado", Nullable = false)]
    public string CpfCnpj { get; set; }

}