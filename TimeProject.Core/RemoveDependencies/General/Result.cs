using TimeProject.Core.Domain.Shared;

namespace TimeProject.Core.RemoveDependencies.General;

public class Result<T> : IResult<T>
{
    public T? Data;
    public bool IsValid => !HasError;
    public bool HasError { get; set; }
    public string? Message { get; set; }
    public string? ActionName { get; set; }

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