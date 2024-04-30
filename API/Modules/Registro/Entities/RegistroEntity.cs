using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Modules.Categoria.Entities;
using API.Modules.Periodo;
using API.Modules.TimePeriod.Entities;
using API.Modules.User.Entities;

namespace API.Modules.Registro.Entities;

[Table("registros_de_tempo")]
public class RegistroEntity
{
    [Key] public int Id { get; set; }
    [Required] public int UsuarioId { get; set; }
    public int? CategoriaId { get; set; }
    [MaxLength(120)] public string? Descricao { get; set; }
    public List<TimePeriodEntity> Periodos { get; set; }

    public virtual UserEntity? Usuario { get; set; }
    public virtual CategoriaEntity? Categoria { get; set; }
}
