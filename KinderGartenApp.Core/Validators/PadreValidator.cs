using FluentValidation;
using KinderGartenApp.Core.Entities;

namespace KinderGartenApp.Core;

public class PadreValidator : AbstractValidator<Padre>
{
    public PadreValidator()
    {
        RuleFor(p => p.Nombre)
            .NotNull();
        //RuleFor(p => p.Email)
        //    .EmailAddress(FluentValidation.Validators.EmailValidationMode)
        //    .WithMessage("Debe estar con el formato 'usuario@dominio'");
        RuleFor(p => p.Password)
            .MinimumLength(8)
            .WithMessage("La contraseña debe contener al menos 8 caracteres");
        RuleFor(p => p.Telefono)
            .MinimumLength(10)
            .WithMessage("El teléfono no tiene al menos diez (10) dígitos");
    }
}