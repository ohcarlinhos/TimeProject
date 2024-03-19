using System.ComponentModel.DataAnnotations.Schema;

namespace API.Modules.RegistroDeTempo.Models;

public class PeriodoDeTempoModel
{
    public DateTime Inicio { get; set; }
    public DateTime Fim { get; set; }
}