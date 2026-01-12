namespace TimeProject.Domain.RemoveDependencies.Dtos.User;

public interface IRecoveryPasswordDto
{
    string Code { get; set; }
    string Email { get; set; }
    string Password { get; set; }
}