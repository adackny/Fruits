using FluentValidation;
using Fruits.Domain.Models;

namespace Fruits.Domain.Validations
{
    public class UpdateFruitValidator : AbstractValidator<Fruit>
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
}
