using App.Infra.Interfaces;
using App.Infrastructure.Interfaces;
using App.Infrastructure.Settings;

namespace App.Infrastructure.Handlers;

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

        message += $"\n\n{DateTime.Now.ToUniversalTime():dd/MM/yyyy HH:mm:ss}";
        
        if (hostEnvironment.IsDevelopment())
        {
            message += $"\n--- DEV ---";
        }

        await customBot.SendMessage(telegramSettings.ChatId, message, threadId);
    }

    public async Task SendError(string message)
    {
        await Send(HookTo.Errors, message);
    }
}