using Telegram.Bot;
using App.Infra.Interfaces;
using App.Infra.Settings;

namespace App.Infra.Integrations;

public class CustomBot(TelegramSettings telegramSettings) : ICustomBot
{
    private readonly TelegramBotClient _client = new(telegramSettings.Key);

    public async Task SendMessage(string chatId, string text) 
    {
        try
        {
            await _client.SendMessage(chatId, text);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}