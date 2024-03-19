namespace PomodoroAPI.Modules.Shared;

public class Result<T>
{
    public bool IsValid => !HasError;
    public bool HasError { get; set; }
    public string? Message { get; set; }
    public T? Data;

    public Result<T> SetError(string? message)
    {
        HasError = true;
        Message = message;
        return this;
    }

    public Result<T> SetData(T data)
    {
        Data = data;
        return this;
    }
}