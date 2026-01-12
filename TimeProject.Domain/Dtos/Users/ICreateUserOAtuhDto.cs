namespace TimeProject.Domain.Dtos.Users;

public interface ICreateUserOAtuhDto
{
    string Name { get; set; }
    string UserProviderId { get; set; }
    int Utc { get; set; }
}