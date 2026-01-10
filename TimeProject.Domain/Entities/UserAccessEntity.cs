namespace TimeProject.Domain.Entities;

public enum AccessType
{
    Password,
    Provider
}

public class UserAccessLogEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }

    public string IpAddress { get; set; } = string.Empty;
    public string UserAgent { get; set; } = string.Empty;

    public AccessType AccessType { get; set; }
    public string Provider { get; set; } = "";

    public DateTime AccessAt { get; set; }
}