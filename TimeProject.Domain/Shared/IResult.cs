using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Domain.Shared;

public interface IResult<T>
{
    public T? Data { get; }
    bool IsValid { get; }
    bool HasError { get; set; }
    string? Message { get; set; }
    string? ActionName { get; set; }
    Result<T> SetError(string? message);
    Result<T> SetData(T data);
}