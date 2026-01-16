using System.ComponentModel.DataAnnotations.Schema;
using TimeProject.Domain.Entities;
using TimeProject.Domain.Entities.Shared;

namespace TimeProject.Infrastructure.Database.Entities.Shared;

public class BaseEntity : IBaseEntity
{
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }
}