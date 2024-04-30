using System.ComponentModel.DataAnnotations;

namespace API.Modules.Auth.Models;

public class LoginModel
{
    [EmailAddress]
    public string Email { get; set; }
    public string Password { get; set; }
}