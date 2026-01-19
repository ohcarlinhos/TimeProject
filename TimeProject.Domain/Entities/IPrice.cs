namespace TimeProject.Domain.Entities;

public interface IPrice
{
    int PriceId { get; set; }
    int? ProjectId { get; set; }
    int? RecordId { get; set; }
    int UserId { get; set; }
    decimal Value { get; set; }
    string Currency { get; set; }
}