using ErrorOr;

namespace Fruits.Application.Wrappers;

public record struct ErrorResponse(string Code, string Description, Dictionary<string, object>? Metadata)
{
    public static implicit operator ErrorResponse(Error error)
    {
        return new ErrorResponse
        {
            Code = error.Code,
            Description = error.Description,
            Metadata = error.Metadata
        };
    }
}