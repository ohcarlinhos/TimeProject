using Telegram.Bot;
using App.Infra.Interfaces;
using App.Infra.Settings;
using Telegram.Bot.Types;

namespace App.Infra.Integrations;

public class CustomBot(TelegramSettings telegramSettings) : ICustomBot
{
    private readonly TelegramBotClient _client = new(telegramSettings.Bot);

    public async Task SendMessage(string chatId, string message, string threadId) 
    {
        try
        {
            await _client.SendMessage(chatId, message, messageThreadId: int.Parse(threadId));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}