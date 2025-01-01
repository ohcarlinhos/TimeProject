namespace App.Infra.Interfaces;

public interface ICustomBot
{
    Task SendMessage(string chatId, string text);
}