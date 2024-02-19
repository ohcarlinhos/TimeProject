using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PomodoroAPI.Modules.Usuario.Entities;

namespace PomodoroAPI.Modules.Categoria.Entities;

[Table("categorias")]
public class CategoriaEntity
{
    [Key]
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    [Required, MinLength(3), MaxLength(120)]
    public string Nome { get; set; }
    public virtual UsuarioEntity? Usuario { get; set; }
}