namespace API.Modules.Category.Entities;

public class CategoryEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    
    public int UserId { get; set; }
    
    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}