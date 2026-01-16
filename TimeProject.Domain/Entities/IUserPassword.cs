namespace TimeProject.Domain.Entities;

public interface IUserPassword
{
    int PasswordId { get; set; }
    int UserId { get; set; }
    string Password { get; set; }
    bool IsActive { get; set; }
}