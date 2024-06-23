using FluentValidation;
using FluentValidation.Results;
using Fruits.Application.Commands;

namespace Fruits.Application.Validators;

public class UpdateFruitValidator : AbstractValidator<UpdateFruitCommand>
{
    public UpdateFruitValidator()
    {
        RuleFor(m => m.Name)
            .NotEmpty()
            .WithMessage("The fruit must have a name.");

        RuleFor(m => m.Colors)
            .Must(c => c is not null && c.Count > 0)
            .WithMessage("The fruit must have at least one color.");
    }
}
