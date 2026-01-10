namespace TimeProject.Infrastructure.Settings;

public class TelegramThreads
{
    public string Errors { get; set; } = "";
    public string Users { get; set; } = "";
    public string Feedbacks { get; set; } = "";
}

public class TelegramSettings
{
    public string Bot { get; set; } = "";
    public string ChatId { get; set; } = "";
    public TelegramThreads Threads { get; set; } = new();
}