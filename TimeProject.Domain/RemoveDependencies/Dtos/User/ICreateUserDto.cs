namespace TimeProject.Domain.RemoveDependencies.Dtos.User;

public interface ICreateUserDto
{
    string Name { get; set; }
    string Email { get; set; }
    string Password { get; set; }
    int Utc { get; set; }
}