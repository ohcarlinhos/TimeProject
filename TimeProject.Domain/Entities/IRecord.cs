namespace TimeProject.Domain.Entities;

public interface IRecord
{
    int Id { get; set; }
    string? Title { get; set; }
    string? Description { get; set; }
    string? ExternalLink { get; set; }
    int UserId { get; set; }
    int? CategoryId { get; set; }
    string Code { get; set; }
}