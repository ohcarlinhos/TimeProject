using App.Infra.Interfaces;
using App.Infra.Settings;

namespace App.Infra.Handlers;

public class HookHandler(ICustomBot customBot, TelegramSettings telegramSettings, IHostEnvironment hostEnvironment)
    : IHookHandler
{
    public async Task Send(HookTo to, string message)
    {
        var threadId = to switch
        {
            HookTo.General => telegramSettings.Threads.General,
            HookTo.Errors => telegramSettings.Threads.Errors,
            HookTo.Users => telegramSettings.Threads.Users,
            _ => telegramSettings.Threads.General
        };

        message += $"\n\n{DateTime.Now:dd/MM/yyyy HH:mm:ss}";
        
        if (hostEnvironment.IsDevelopment())
        {
            message += $"\n--- DEV ---";
        }

        await customBot.SendMessage(telegramSettings.ChatId, message, threadId);
    }
}