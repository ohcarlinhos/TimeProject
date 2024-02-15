using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PomodoroAPI.Modules.Usuario.Models;

namespace PomodoroAPI.Modules.RegistroDeTempo.Models;

[Table("periodos_de_tempo")]
public class PeriodoDeTempoModelView
{
    public DateTime Inicio { get; set; }
    public DateTime Fim { get; set; }
}