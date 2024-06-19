using FluentValidation;
using Fruits.Domain.Models;

namespace Fruits.Domain.Validations;

public class FruitsValidator : AbstractValidator<Fruit>
{
    public FruitsValidator()
    {
        RuleFor(m => m.Name).NotEmpty().WithMessage("La fruta debe tener un nombre");
        RuleFor(m => m.Caducity)
            .Must(d => d >= DateOnly.FromDateTime(DateTime.Now.AddDays(3)))
            .WithMessage("La fecha de caducidad debe ser de al menos 3 días después de hoy");
        RuleFor(m => m.Colors).Must(c => c is not null && c.Count > 0)
            .WithMessage("La fruta debe tener al menos un color");
    }
}
