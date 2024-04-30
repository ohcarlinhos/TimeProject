using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Modules.Registro.Entities;
using API.Modules.User.Entities;

namespace API.Modules.Periodo.Entities;

[Table("periodos_de_tempo")]
public class PeriodoEntity
{
    [Key] public int Id { get; set; }
    [Required] public int UsuarioId { get; set; }
    [Required] public int RegistroId { get; set; }
    [Required] public DateTime Inicio { get; set; }
    [Required] public DateTime Fim { get; set; }

    public virtual UsuarioEntity? Usuario { get; set; }
    public virtual RegistroEntity? Registro { get; set; }
}