using App.Infra.Interfaces;
using App.Infra.Settings;

namespace App.Infra.Handlers;

public class HookHandler(ICustomBot customBot, TelegramSettings telegramSettings) : IHookHandler
{
    public async Task Send(HookTo to, string message)
    {
        var chatId = to switch
        {
            HookTo.General => telegramSettings.Chats.General,
            HookTo.Users => telegramSettings.Chats.Users,
            _ => telegramSettings.Chats.General
        };

        await customBot.SendMessage(chatId, message);
    }
}