using System.ComponentModel.DataAnnotations;

namespace PomodoroAPI.Modules.Auth.Models;

public class CredenciaisModelView
{
    [EmailAddress]
    public string Email { get; set; }
    public string Senha { get; set; }
}