using API.Modules.Category.Entities;
using API.Modules.TimePeriod.Entities;

namespace API.Modules.TimeRecord.Entities;

public class TimeRecord
{
    public int Id { get; set; }
    public string? Description { get; set; }
    
    public int UserId { get; set; }
    public int? CategoryId { get; set; }
    
    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    
    public virtual ICollection<TimePeriodEntity>? TimePeriods { get; set; }
    public virtual CategoryEntity? Category { get; set; }
}
