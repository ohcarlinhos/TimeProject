using System.ComponentModel.DataAnnotations;

namespace API.Modules.TimeRecord.Models;

public class UpdateTimeRecordModel
{
    [MaxLength(120)] public string? Description { get; set; }
    public int? CategoryId { get; set; }
}