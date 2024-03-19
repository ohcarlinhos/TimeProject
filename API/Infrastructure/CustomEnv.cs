namespace PomodoroAPI.Infrastructure;

public class CustomEnv
{
    public static string? Get(string name)
    {
        return Environment.GetEnvironmentVariable(name);
    }
}