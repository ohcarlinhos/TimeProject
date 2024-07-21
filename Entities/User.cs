namespace Entities;

public enum UserRole
{
    Admin,
    NormalUser,
    PayingUser,
    GuestUser
}

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public UserRole UserRole { get; set; } = UserRole.NormalUser;
    public bool IsActive { get; set; } = true;
    
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}