namespace App.Infra.Settings;

public class TelegramChats
{
    public string General { get; set; }
    public string Users { get; set; }
}

public class TelegramSettings
{
    public string Key { get; set; }
    public TelegramChats Chats { get; set; } = new TelegramChats();
}