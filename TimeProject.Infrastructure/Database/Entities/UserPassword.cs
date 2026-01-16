using System.ComponentModel.DataAnnotations.Schema;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Database.Entities.Shared;

namespace TimeProject.Infrastructure.Database.Entities;

[Table("user_passwords")]
public class UserPassword : WithOwnerEntity, IUserPassword
{
    [Column("password_id")] public int PasswordId { get; set; }
    [Column("password")] public string Password { get; set; } = string.Empty;
    [Column("is_active")] public bool IsActive { get; set; }
}