using App.Infrastructure.Interfaces;
using Telegram.Bot;
using App.Infrastructure.Settings;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace App.Infrastructure.Integrations;

public class CustomBot(TelegramSettings telegramSettings) : ICustomBot
{
    private readonly TelegramBotClient _client = new(telegramSettings.Bot);

    public async Task SendMessage(string chatId, string message, string? threadId)
    {
        try
        {
            await _client
                .SendMessage(chatId, message, messageThreadId: threadId != null ? int.Parse(threadId) : null,
                    parseMode: ParseMode.Html);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}