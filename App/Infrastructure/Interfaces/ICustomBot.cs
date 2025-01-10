namespace App.Infrastructure.Interfaces;

public interface ICustomBot
{
    Task SendMessage(string chatId, string message, string? threadId);
}