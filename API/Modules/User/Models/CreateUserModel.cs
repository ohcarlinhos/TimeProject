using System.ComponentModel.DataAnnotations;

namespace API.Modules.User.Models;

public class CreateUserModel
{
    public string Name { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    public string Password { get; set; }
}