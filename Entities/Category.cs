namespace Entities;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    
    public int UserId { get; set; }
    
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}