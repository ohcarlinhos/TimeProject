using System.ComponentModel.DataAnnotations.Schema;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Database.Entities.Enums;
using TimeProject.Infrastructure.Database.Entities.Shared;

namespace TimeProject.Infrastructure.Database.Entities;

[Table("users")]
public class User : BaseEntity, IUser
{
    [Column("user_id")] public int Id { get; set; }
    [Column("name")] public string Name { get; set; } = null!;
    [Column("email")] public string Email { get; set; } = null!;
    [Column("user_role")] public UserRoleType UserRole { get; set; } = UserRoleType.Normal;
    [Column("timezone")] public int Utc { get; set; }
    [Column("is_active")] public bool IsActive { get; set; } = true;
}