using System.ComponentModel.DataAnnotations.Schema;

namespace API.Modules.RegistroDeTempo.Models;

public class CreatePeriodoDeTempoModel
{
    public int RegistroId { get; set; }
    public DateTime Inicio { get; set; }
    public DateTime Fim { get; set; }
}