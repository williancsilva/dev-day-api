using DevSecOps.backoffice.App.Dto.Signature;
using DevSecOps.backoffice.App.Validators.CustomValidator;
using FluentValidation;

namespace DevSecOps.backoffice.App.Validators;

public class ObterDadosClienteValidator : AbstractValidator<ObterDadosClienteSignature>
{
    public ObterDadosClienteValidator()
    {
        RuleFor(x => x.CpfCnpj).Must(DocumentoValidator.ValidarDocumento).WithMessage("Documento Inválido");
    }
}