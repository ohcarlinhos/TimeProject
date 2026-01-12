namespace TimeProject.Domain.Entities;

public interface IUserPassword
{
    int UserId { get; set; }
    string Password { get; set; }
}