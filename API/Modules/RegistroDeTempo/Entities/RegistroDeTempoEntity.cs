using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Modules.Categoria.Entities;
using API.Modules.Usuario.Entities;

namespace API.Modules.RegistroDeTempo.Entities;

[Table("registros_de_tempo")]
public class RegistroDeTempoEntity
{
    [Key] public int Id { get; set; }
    [Required] public int UsuarioId { get; set; }
    public int? CategoriaId { get; set; }
    [Required, MaxLength(120)] public string? Titulo { get; set; }

    [Required] public DateTime? DataDoRegistro { get; set; }
    public List<PeriodoDeTempoEntity> Periodos { get; set; }

    public virtual UsuarioEntity? Usuario { get; set; }
    public virtual CategoriaEntity? Categoria { get; set; }
}
