namespace Entities;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    
    public int UserId { get; set; }
    
    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}