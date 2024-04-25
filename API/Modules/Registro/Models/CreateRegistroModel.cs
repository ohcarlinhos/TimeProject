using System.ComponentModel.DataAnnotations;
using API.Modules.Periodo.Models;

namespace API.Modules.Registro.Models;

public class CreateRegistroModel
{
    public int? CategoriaId { get; set; }
    [MaxLength(120)] public string? Descricao { get; set; }
    [Required] public List<PeriodoModel>? Periodos { get; set; }
}