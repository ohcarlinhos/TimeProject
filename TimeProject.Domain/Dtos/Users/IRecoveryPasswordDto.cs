namespace TimeProject.Domain.Dtos.Users;

public interface IRecoveryPasswordDto
{
    string Code { get; set; }
    string Email { get; set; }
    string Password { get; set; }
}