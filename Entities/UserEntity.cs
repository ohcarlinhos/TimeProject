namespace Entities;

public enum UserRole
{
    Admin,
    Normal,
    Beta,
}

public class UserEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public UserRole UserRole { get; set; } = UserRole.Normal;
    public int Utc { get; set; }
    
    public bool IsActive { get; set; } = true;
    public bool IsVerified { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}