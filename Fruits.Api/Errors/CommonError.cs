using ErrorOr;

namespace Fruits.Api.Errors
{
    public static class CommonError
    {
        public static Error IdMismatch => Error.Validation
        (
            code: "id-mismatch",
            description: "The Id in the path and the Id in the body must match.",
            []
        );
    }
}
