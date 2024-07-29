using System.ComponentModel.DataAnnotations;

namespace API.Modules.TimeRecord.Dto;

public class UpdateTimeRecordDto
{
    [MaxLength(120)] public string? Title { get; set; }
    [MaxLength(240)] public string? Description { get; set; }
    [MaxLength(120)] public string? ExternalLink { get; set; }
    [MaxLength(36)] public string Code { get; set; }
    public int? CategoryId { get; set; }
}