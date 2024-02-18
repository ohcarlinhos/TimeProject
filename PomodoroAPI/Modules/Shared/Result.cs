namespace PomodoroAPI.Modules.Shared;

public class Result<T>
{
    public bool IsValid { get; set; }
    public bool HasError => !IsValid;
    public string? Message { get; set; }
    public T? Data;
}