namespace TimeProject.Domain.RemoveDependencies.Dtos.User;

public interface IUpdatePasswordDto
{
    string Password { get; set; }
    string OldPassword { get; set; }
}