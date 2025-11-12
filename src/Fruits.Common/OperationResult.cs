namespace Fruits.Common;

public record OperationError(string Message);

public readonly struct Unit
{
    public static Unit Value => new();
}

public class OperationResult<T>(T? value)
{
    private T? _value = value;
    private OperationError? _error;

    public OperationResult(OperationError error) : this((T?)default)
    {
        _error = error;
    }

    public T? Value => _value;

    public OperationError? Error => _error;

    public bool HasError => _error is not null;

    public OperationResult<T> SetValue(T value)
    {
        _value = value;
        return this;
    }

    public OperationResult<T> SetError(OperationError error)
    {
        _error = error;
        return this;
    }

    public static implicit operator OperationResult<T>(T value) => new(value);

    public static implicit operator OperationResult<T>(OperationError error) => new(error);

    public T? Propagate()
    {
        if (_error is not null)
            throw new OperationResultFailedException(_error);
        return _value;
    }
}

public class OperationResultFailedException(OperationError operationError) : Exception()
{
    public OperationError OperationError => operationError;
}

public static class Operation
{
    public static OperationResult<T> Run<T>(Func<OperationResult<T>> runner)
    {
        try
        {
            return runner();
        }
        catch (OperationResultFailedException e)
        {
            return e.OperationError;
        }
    }
}