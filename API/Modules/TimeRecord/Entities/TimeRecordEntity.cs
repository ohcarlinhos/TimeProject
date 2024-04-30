using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Modules.Category.Entities;
using API.Modules.TimePeriod.Entities;
using API.Modules.User.Entities;

namespace API.Modules.TimeRecord.Entities;

[Table("time_records")]
public class TimeRecordEntity
{
    [Key] public int Id { get; set; }
    [Required] public int UserId { get; set; }
    public int? CategoryId { get; set; }
    [MaxLength(120)] public string? Description { get; set; }
    public List<TimePeriodEntity>? TimePeriods { get; set; }

    public virtual UserEntity? User { get; set; }
    public virtual CategoryEntity? Category { get; set; }
}
