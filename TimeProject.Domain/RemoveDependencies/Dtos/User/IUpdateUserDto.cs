namespace TimeProject.Domain.RemoveDependencies.Dtos.User;

public interface IUpdateUserDto
{
    string? Name { get; set; }
    string? Email { get; set; }
    string? Password { get; set; }
    int? Utc { get; set; }
}