using System.ComponentModel.DataAnnotations;

namespace PomodoroAPI.Modules.Auth.Models;

public class LoginRequest
{
    [EmailAddress]
    public string Email { get; set; }
    public string Senha { get; set; }
}