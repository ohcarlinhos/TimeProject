namespace TimeProject.Domain.Dtos.Auths;

public interface ILoginDto
{
    string Email { get; set; }
    string Password { get; set; }
}