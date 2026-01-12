namespace TimeProject.Domain.RemoveDependencies.Dtos.Auth;

public interface ILoginDto
{
    string Email { get; set; }
    string Password { get; set; }
}