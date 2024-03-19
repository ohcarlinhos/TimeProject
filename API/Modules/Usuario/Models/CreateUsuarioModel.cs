using System.ComponentModel.DataAnnotations;

namespace PomodoroAPI.Modules.Usuario.Models;

public class CreateUsuarioModel
{
    public string Nome { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    public string Senha { get; set; }
}