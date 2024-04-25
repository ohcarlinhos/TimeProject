using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Modules.Registro;
using API.Modules.Usuario.Entities;

namespace API.Modules.Periodo;

[Table("periodos_de_tempo")]
public class PeriodoEntity
{
    [Key] public int Id { get; set; }
    [Required] public int UsuarioId { get; set; }
    [Required] public int RegistroDeTempoId { get; set; }
    [Required] public DateTime Inicio { get; set; }
    [Required] public DateTime Fim { get; set; }

    public virtual UsuarioEntity? Usuario { get; set; }
    public virtual RegistroEntity? RegistroDeTempo { get; set; }
}