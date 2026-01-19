using TimeProject.Domain.Entities;

namespace TimeProject.Infrastructure.Database.Entities;

public class Category : ICategory
{
    public int CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int UserId { get; set; }
}