using TimeProject.Domain.Entities;

namespace TimeProject.Infrastructure.Database.Entities;

public class Customer : ICustomer
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public int UserId { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}