namespace TimeProject.Domain.Dtos.Users;

public interface ICreateUserDto
{
    string Name { get; set; }
    string Email { get; set; }
    string Password { get; set; }
    int Utc { get; set; }
}