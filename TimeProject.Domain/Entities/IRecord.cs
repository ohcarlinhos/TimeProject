namespace TimeProject.Domain.Entities;

public interface IRecord
{
    int RecordId { get; set; }
    string? Name { get; set; }
    string? Description { get; set; }
    string? ExternalLink { get; set; }
    int UserId { get; set; }
    int? CategoryId { get; set; }
    string Code { get; set; }
}