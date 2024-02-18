using System.ComponentModel.DataAnnotations;

namespace PomodoroAPI.Modules.RegistroDeTempo.Models;

public class RegistroDeTempoModelView
{
    public int? CategoriaId { get; set; }
    [Required, MaxLength(120)] public string? Titulo { get; set; }
    [Required] public DateTime DataDoRegistro { get; set; }
    [Required] public List<PeriodoDeTempoModelView>? Periodos { get; set; }
}