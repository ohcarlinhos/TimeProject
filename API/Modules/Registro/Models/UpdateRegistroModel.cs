using System.ComponentModel.DataAnnotations;

namespace API.Modules.Registro.Models;

public class UpdateRegistroModel
{
    [MaxLength(120)] public string? Descricao { get; set; }
    public int? CategoriaId { get; set; }
}