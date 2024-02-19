using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PomodoroAPI.Modules.Usuario.Entities;

namespace PomodoroAPI.Modules.RegistroDeTempo.Entities;

[Table("periodos_de_tempo")]
public class PeriodoDeTempoEntity
{
    [Key] public int Id { get; set; }
    [Required] public int UsuarioId { get; set; }
    [Required] public int RegistroDeTempoId { get; set; }
    [Required] public DateTime Inicio { get; set; }
    [Required] public DateTime Fim { get; set; }

    public virtual UsuarioEntity? Usuario { get; set; }
    public virtual RegistroDeTempoEntity? RegistroDeTempo { get; set; }
}