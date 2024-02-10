using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PomodoroAPI.Models;

[Table("tempos_focado")]
public class TempoFocado
{
    [Key]
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public virtual Usuario? Usuario { get; set; }
    public int CategoriaId { get; set; }
    public virtual Categoria? Categoria { get; set; }
    [Required, MinLength(3), MaxLength(120)]
    public string? Titulo { get; set; }
    public DateTime DataDeRegistro { get; set; }
    public EventoDeFoco[] Eventos { get; set; }
}