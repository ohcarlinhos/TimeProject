using System.ComponentModel.DataAnnotations;

namespace API.Modules.User.Models;

public class CreateUserModel
{
    [MinLength(2), MaxLength(120)]
    public string Name { get; set; }
    [EmailAddress, MaxLength(64)]
    public string Email { get; set; }
    public string RegisterCode { get; set; }
    [MinLength(8), MaxLength(48)]
    public string Password { get; set; }
}