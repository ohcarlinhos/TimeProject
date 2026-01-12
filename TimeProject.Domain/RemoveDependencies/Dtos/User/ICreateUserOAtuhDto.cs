namespace TimeProject.Domain.RemoveDependencies.Dtos.User;

public interface ICreateUserOAtuhDto
{
    string Name { get; set; }
    string UserProviderId { get; set; }
    int Utc { get; set; }
}