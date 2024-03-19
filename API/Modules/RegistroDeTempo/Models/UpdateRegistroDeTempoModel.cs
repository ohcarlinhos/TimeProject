using System.ComponentModel.DataAnnotations;

namespace PomodoroAPI.Modules.RegistroDeTempo.Models;

public class UpdateRegistroDeTempoModel
{
    [MaxLength(120)] public string? Titulo { get; set; }
    public DateTime? DataDoRegistro { get; set; }
    public int? CategoriaId { get; set; }
}