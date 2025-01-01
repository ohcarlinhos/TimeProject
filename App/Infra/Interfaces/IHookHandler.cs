namespace App.Infra.Interfaces;

public enum HookTo
{
    General,
    Errors,
    Users
}

public interface IHookHandler
{
    public Task Send(HookTo to, string message);
}