namespace TimeProject.Core.Domain.Entities;

public class PriceEntity
{
    public int Id { get; set; }

    public int? ProjectId { get; set; }
    public int? TimeRecordId { get; set; }

    public int UserId { get; set; }

    public decimal Value { get; set; }
    public string Currency { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}