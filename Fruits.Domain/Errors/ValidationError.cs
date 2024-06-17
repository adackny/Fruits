namespace Fruits.Domain.Errors;

    public record class ValidationError(string ErrorCode, string Message, Dictionary<string, object> Details)
        : Error(ErrorCode, Message, Details);
