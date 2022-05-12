using Dayconnect.backoffice.App.Dto.Signature;
using Dayconnect.backoffice.App.Validators.CustomValidator;
using FluentValidation;

namespace Dayconnect.backoffice.App.Validators;

public class ObterDadosClienteValidator : AbstractValidator<ObterDadosClienteSignature>
{
    public ObterDadosClienteValidator()
    {
        RuleFor(x => x.CpfCnpj).Must(DocumentoValidator.ValidarDocumento).WithMessage("Documento Inválido");
    }
}