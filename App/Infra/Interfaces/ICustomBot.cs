namespace App.Infra.Interfaces;

public interface ICustomBot
{
    Task SendMessage(string chatId, string message, string threadId);
}