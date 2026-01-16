namespace TimeProject.Domain.Dtos.Users;

public interface IUpdateUserDto
{
    string? Name { get; set; }
    string? Email { get; set; }
    string? Password { get; set; }
    string? Timezone { get; set; }
}