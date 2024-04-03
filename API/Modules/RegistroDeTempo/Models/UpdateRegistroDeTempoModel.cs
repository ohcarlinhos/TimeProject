using System.ComponentModel.DataAnnotations;

namespace API.Modules.RegistroDeTempo.Models;

public class UpdateRegistroDeTempoModel
{
    [MaxLength(120)] public string? Descricao { get; set; }
    public int? CategoriaId { get; set; }
}