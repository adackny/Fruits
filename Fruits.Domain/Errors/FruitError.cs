namespace Fruits.Domain.Errors
{
    public static class FruitError
    {
        public static ErrorOr.Error InvalidModel => ErrorOr.Error.Validation
        (
            code: "fruit-validation",
            description: "Fruit model validation failed.",
            []
        );

        public static ErrorOr.Error FruitNotFound => ErrorOr.Error.NotFound(
            code: "fruit-not-found",
            description: "Fruit not found.",
            []);
    }
}
