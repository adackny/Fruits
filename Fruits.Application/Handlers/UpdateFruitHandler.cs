using Ardalis.Specification;
using ErrorOr;
using FluentValidation;
using Fruits.Application.Commands;
using Fruits.Domain.Errors;
using Fruits.Domain.Models;
using MediatR;

namespace Fruits.Application.Handlers
{
    public class UpdateFruitHandler : IRequestHandler<UpdateFruitCommand, ErrorOr<Fruit?>>
    {
        private readonly FruitsService _fruitsService;
        private readonly IValidator<UpdateFruitCommand> _validator;

        public UpdateFruitHandler(
            FruitsService fruitsService,
            IValidator<UpdateFruitCommand> validator)
        {
            _fruitsService = fruitsService;
            _validator = validator;
        }

        public async Task<ErrorOr<Fruit?>> Handle(UpdateFruitCommand request, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
            {
                var error = FruitError.InvalidModel;

                foreach (var validation in validationResult.Errors)
                {
                    error.Metadata?.Add(validation.PropertyName, validation.ErrorMessage);
                }

                return error;
            }

            Fruit fruit = request;
            ErrorOr<Fruit?> result = await _fruitsService.UpdateAsync(fruit);

            return result;
        }
    }
}
