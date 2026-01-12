using TimeProject.Domain.Entities;

namespace TimeProject.Infrastructure.Entities;

public class Price : IPrice
{
    public int Id { get; set; }

    public int? ProjectId { get; set; }
    public int? RecordId { get; set; }

    public int UserId { get; set; }

    public decimal Value { get; set; }
    public string Currency { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}