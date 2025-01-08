namespace App.Infrastructure.Interfaces;

public enum HookTo
{
    General,
    Errors,
    Users
}

public interface IHookHandler
{
    public Task Send(HookTo to, string message);
    public Task SendError(string message);
}