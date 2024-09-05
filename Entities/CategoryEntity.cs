namespace Entities;

public class CategoryEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public int UserId { get; set; }
    
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}