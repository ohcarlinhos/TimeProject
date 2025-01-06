namespace App.Infra.Settings;

public class TelegramThreads
{
    public string General { get; set; }
    public string Errors { get; set; }
    public string Users { get; set; }
}

public class TelegramSettings
{
    public string Bot { get; set; }
    public string ChatId { get; set; }
    public TelegramThreads Threads { get; set; } = new();
}