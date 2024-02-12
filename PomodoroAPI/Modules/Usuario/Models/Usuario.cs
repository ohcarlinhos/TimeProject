using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PomodoroAPI.Modules.Usuario.Models;

[Table("usuarios"), Index(nameof(Email), IsUnique = true)]
public class UsuarioModel
{
    [Key] public int Id { get; set; }

    [Required, MinLength(3), MaxLength(120)]
    public string Nome { get; set; }

    [Required, EmailAddress, MinLength(8), MaxLength(64)]
    public string Email { get; set; }

    [Required, MinLength(8), MaxLength(32)]
    public string? Senha { get; set; }
}