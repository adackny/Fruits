using ErrorOr;

namespace Fruits.Domain.Errors
{
    public static class FruitError
    {
        public static Error InvalidModel => Error.Validation
        (
            code: "fruit-validation",
            description: "Fruit model validation failed.",
            []
        );

        public static Error FruitNotFound => Error.NotFound(
            code: "fruit-not-found",
            description: "Fruit not found.",
            []);
    }
}
