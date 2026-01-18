namespace TimeProject.Domain.Entities;

public interface IUserProvider
{
    int ProviderId { get; set; }
    int UserId { get; set; }
    string Provider { get; set; }
    string ExternalId { get; set; }
}