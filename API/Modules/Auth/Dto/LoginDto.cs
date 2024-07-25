using System.ComponentModel.DataAnnotations;

namespace API.Modules.Auth.Dto;

public class LoginDto
{
    [EmailAddress]
    public string Email { get; set; }
    public string Password { get; set; }
}