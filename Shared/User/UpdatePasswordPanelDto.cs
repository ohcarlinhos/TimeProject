using System.ComponentModel.DataAnnotations;

namespace Shared.User;

public class UpdatePasswordPanelDto
{
    [MinLength(8), MaxLength(48), Required]
    public string Password { get; set; } = string.Empty;
}