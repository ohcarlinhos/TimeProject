namespace PomodoroAPI.Modules.Shared;

public class Result<T>
{
    public bool IsValid => !HasError;
    public bool HasError { get; set; }
    public string? Message { get; set; }
    public T? Data;
}