using System.ComponentModel.DataAnnotations;

namespace API.Modules.RegistroDeTempo.Models;

public class CreateRegistroDeTempoModel
{
    public int? CategoriaId { get; set; }
    [MaxLength(120)] public string? Descricao { get; set; }
    [Required] public List<PeriodoDeTempoModel>? Periodos { get; set; }
}