namespace TimeProject.Domain.Entities;

public interface IOAuth
{
    int UserId { get; set; }
    string Provider { get; set; }
    string UserProviderId { get; set; }
}