﻿using Dayconnect.Fidelity.App.Dto.Signature;
using Dayconnect.Fidelity.App.Validators.CustomValidator;
using FluentValidation;

namespace Dayconnect.Fidelity.App.Validators
{
    public class ObterDadosClienteValidator : AbstractValidator<ObterDadosClienteSignature>
    {
        public ObterDadosClienteValidator()
        {
            RuleFor(x => x.CpfCnpj).Must(DocumentoValidator.ValidarDocumento).WithMessage("Documento Inválido");
        }
    }
}
