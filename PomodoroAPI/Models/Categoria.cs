using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PomodoroAPI.Models;

[Table("categorias")]
public class Categoria
{
    [Key]
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    [Required, MinLength(3), MaxLength(120)]
    public int Nome { get; set; }
    public virtual Usuario? Usuario { get; set; }
}