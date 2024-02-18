using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PomodoroAPI.Modules.Usuario.Entities;
using PomodoroAPI.Modules.Usuario.Models;

namespace PomodoroAPI.Modules.RegistroDeTempo.Models;

[Table("periodos_de_tempo")]
public class PeriodoDeTempoModel
{
    [Key] public int Id { get; set; }
    [Required] public int UsuarioId { get; set; }
    [Required] public int RegistroDeTempoId { get; set; }
    [Required] public DateTime Inicio { get; set; }
    [Required] public DateTime Fim { get; set; }

    public virtual UsuarioEntity? Usuario { get; set; }
    public virtual RegistroDeTempoModel? RegistroDeTempo { get; set; }
}