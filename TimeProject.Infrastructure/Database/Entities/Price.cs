using TimeProject.Domain.Entities;

namespace TimeProject.Infrastructure.Database.Entities;

public class Price : IPrice
{
    public int PriceId { get; set; }
    public int? ProjectId { get; set; }
    public int? RecordId { get; set; }
    public decimal Value { get; set; }
    public string Currency { get; set; } = string.Empty;
    public int UserId { get; set; }
}