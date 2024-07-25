using System.ComponentModel.DataAnnotations;

namespace API.Modules.TimeRecord.Dto;

public class UpdateTimeRecordDto
{
    [MaxLength(240)] public string? Description { get; set; }
    [MaxLength(120)] public string? ExternalLink { get; set; }
    public int? CategoryId { get; set; }
    [MaxLength(32)] public string? Code { get; set; }
}