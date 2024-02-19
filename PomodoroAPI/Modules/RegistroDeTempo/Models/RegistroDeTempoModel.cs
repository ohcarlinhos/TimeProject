using System.ComponentModel.DataAnnotations;

namespace PomodoroAPI.Modules.RegistroDeTempo.Models;

public class RegistroDeTempoModel
{
    public int? CategoriaId { get; set; }
    [Required, MaxLength(120)] public string? Titulo { get; set; }
    [Required] public DateTime DataDoRegistro { get; set; }
    [Required] public List<PeriodoDeTempoModel>? Periodos { get; set; }
}