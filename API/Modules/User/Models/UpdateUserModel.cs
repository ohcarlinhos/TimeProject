using System.ComponentModel.DataAnnotations;

namespace API.Modules.User.Models;

public class UpdateUserModel
{
    public string? Name { get; set; }
    [EmailAddress]
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? OldPassword { get; set; }
}