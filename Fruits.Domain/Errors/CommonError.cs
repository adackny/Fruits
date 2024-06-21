using ErrorOr;

namespace Fruits.Domain.Errors
{
    public static class CommonError
    {
        public static Error InvalidId => Error.Validation
        (
            code: "id-validation",
            description: "Id validation failed.",
            new() { ["id"] = "It must be greater than zero." }
        );
    }
}
