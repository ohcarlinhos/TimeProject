using System.ComponentModel.DataAnnotations.Schema;
using TimeProject.Domain.Entities;
using TimeProject.Domain.Entities.Enums;
using TimeProject.Infrastructure.Database.Entities.Shared;

namespace TimeProject.Infrastructure.Database.Entities;

[Table("confirm_codes")]
public class ConfirmCode : WithOwnerEntity, IConfirmCode
{
    [Column("code_id")] public string CodeId { get; set; } = null!;
    [Column("type")] public ConfirmCodeType Type { get; set; }
    [Column("is_used")] public bool IsUsed { get; set; }
    [Column("was_sent")] public bool WasSent { get; set; }
    [Column("expitation")] public DateTime Expiration { get; set; }

    public User? User { get; set; }
}