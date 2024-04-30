using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Modules.TimeRecord.Entities;
using API.Modules.User.Entities;

namespace API.Modules.TimePeriod.Entities;

[Table("time_periods")]
public class TimePeriodEntity
{
    [Key] public int Id { get; set; }
    [Required] public int UserId { get; set; }
    [Required] public int TimerRecordId { get; set; }
    [Required] public DateTime Start { get; set; }
    [Required] public DateTime End { get; set; }

    public virtual UserEntity? User { get; set; }
    public virtual TimeRecordEntity? TimeRecord { get; set; }
}