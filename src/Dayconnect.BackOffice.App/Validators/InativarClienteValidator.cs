using DevSecOps.backoffice.App.Dto.Signature;
using DevSecOps.backoffice.App.Validators.CustomValidator;
using FluentValidation;

namespace DevSecOps.backoffice.App.Validators;

public class InativarClienteValidator : AbstractValidator<InativarClienteSignature>
{
    public InativarClienteValidator()
    {
        RuleFor(x => x.CpfCnpj).Must(DocumentoValidator.ValidarDocumento).WithMessage("Documento Inválido");
    }
}