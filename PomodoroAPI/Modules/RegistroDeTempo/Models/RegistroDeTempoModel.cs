using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PomodoroAPI.Modules.Categoria.Models;
using PomodoroAPI.Modules.Usuario.Models;

namespace PomodoroAPI.Modules.RegistroDeTempo.Models;

[Table("registros_de_tempo")]
public class RegistroDeTempoModel
{
    [Key] public int Id { get; set; }
    [Required] public int UsuarioId { get; set; }
    public int? CategoriaId { get; set; }

    [Required, MaxLength(120)] public string? Titulo { get; set; }

    [Required] public DateTime DataDoRegistro { get; set; }
    public List<PeriodoDeTempoModel> Periodos { get; set; }

    public virtual UsuarioModel? Usuario { get; set; }
    public virtual CategoriaModel? Categoria { get; set; }
}