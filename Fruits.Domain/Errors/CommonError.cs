namespace Fruits.Domain.Errors
{
    public static class CommonError
    {
        public static ErrorOr.Error InvalidId => ErrorOr.Error.Validation
        (
            code: "id-validation",
            description: "Id validation failed.",
            new() { ["id"] = "It must be greater than zero." }
        );
    }
}
