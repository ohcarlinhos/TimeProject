using System.ComponentModel.DataAnnotations;

namespace API.Modules.TimeRecord.Dto;

public class UpdateTimeRecordDto
{
    [MaxLength(120)] public string? Description { get; set; }
    public int? CategoryId { get; set; }
    [MaxLength(32)] public string? Code { get; set; }
}