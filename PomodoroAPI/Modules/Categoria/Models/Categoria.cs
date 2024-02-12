using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PomodoroAPI.Modules.Usuario.Models;

namespace PomodoroAPI.Models;

[Table("categorias")]
public class Categoria
{
    [Key]
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    [Required, MinLength(3), MaxLength(120)]
    public string Nome { get; set; }
    public virtual Usuario? Usuario { get; set; }
}