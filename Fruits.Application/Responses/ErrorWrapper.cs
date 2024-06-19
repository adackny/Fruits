using ErrorOr;

namespace Fruits.Application.Wrappers;

public record struct ErrorWrapper(string Code, string Description, Dictionary<string, object>? Metadata)
{
    public static implicit operator ErrorWrapper(Error error)
    {
        return new ErrorWrapper
        {
            Code = error.Code,
            Description = error.Description,
            Metadata = error.Metadata
        };
    }
}