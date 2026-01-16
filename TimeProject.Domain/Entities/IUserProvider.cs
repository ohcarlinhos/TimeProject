namespace TimeProject.Domain.Entities;

public interface IUserProvider
{
    int UserId { get; set; }
    string Provider { get; set; }
    string UserProviderId { get; set; }
}