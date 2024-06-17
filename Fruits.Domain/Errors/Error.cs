namespace Fruits.Domain.Errors;

public record class Error(string ErrorCode, string Message, Dictionary<string, object> Details);