namespace Fruits.Domain.Errors;

public record class ModelError(string ErrorCode, Dictionary<string, string> Details);