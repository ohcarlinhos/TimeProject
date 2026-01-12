namespace TimeProject.Domain.Dtos.Users;

public interface IUpdatePasswordDto
{
    string Password { get; set; }
    string OldPassword { get; set; }
}