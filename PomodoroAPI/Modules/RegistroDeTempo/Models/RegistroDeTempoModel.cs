using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PomodoroAPI.Modules.Categoria.Models;
using PomodoroAPI.Modules.Usuario.Models;

namespace PomodoroAPI.Modules.RegistroDeTempo.Models;

[Table("registros_de_tempo")]
public class RegistroDeTempoModel
{
    [Key]
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public virtual UsuarioModel? Usuario { get; set; }
    public int CategoriaId { get; set; }
    public virtual CategoriaModel? Categoria { get; set; }
    [Required, MinLength(3), MaxLength(120)]
    public string? Titulo { get; set; }
    public DateTime DataDeRegistro { get; set; }
    public EventoModel[] Eventos { get; set; }
}