using FluentValidation;
using Fruits.Domain.Models;

namespace Fruits.Domain.Validations;

public class CreateFruitValidator : AbstractValidator<Fruit>
{
    public CreateFruitValidator()
    {
        RuleFor(m => m.Name)
            .NotEmpty()
            .WithMessage("The fruit must have a name.");

        RuleFor(m => m.Caducity)
            .Must(d => d >= DateOnly.FromDateTime(DateTime.Now.AddDays(3)))
            .WithMessage("The expiration date must be at least 3 days from today.");

        RuleFor(m => m.Colors)
            .Must(c => c is not null && c.Count > 0)
            .WithMessage("The fruit must have at least one color.");
    }
}
