using Dayconnect.backoffice.App.Dto.Signature;
using FluentValidation;

namespace Dayconnect.backoffice.App.Validators;

public class LoginValidator : AbstractValidator<LoginSignature>
{
    public LoginValidator()
    {
        RuleFor(x => x.Login).NotNull().NotEmpty().WithMessage("Código Login Obrigatório");
        RuleFor(x => x.Login).Must(y => y.Length <= 150).Unless(x => string.IsNullOrWhiteSpace(x.Login)).WithMessage("Código Login Inválido");
        RuleFor(x => x.Login).EmailAddress().When(x => !string.IsNullOrWhiteSpace(x.Login) && x.Login.Length > 15).WithMessage("Formato Invalido");
        RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage("Senha Obrigatória");
        RuleFor(x => x.Password).Must(y => y.Length >= 8).Unless(x => string.IsNullOrWhiteSpace(x.Password)).WithMessage("Formato Invalido");
        RuleFor(x => x.DeviceId).NotNull().NotEmpty().WithMessage("DeviceId Obrigatório");
        RuleFor(x => x.VersaoDispositivo).NotNull().NotEmpty().WithMessage("Versão Dispositivo Obrigatório");
    }
}