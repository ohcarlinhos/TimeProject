using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PomodoroAPI.Enums;
using PomodoroAPI.Modules.Usuario.Models;

namespace PomodoroAPI.Models;

[Table("eventos_de_foco")]
public class EventoDeFoco
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public virtual Usuario? Usuario { get; set; }
    public int TempoFocadoId { get; set; }
    public DateTime DataDeRegistro { get; set; }
    public TipoDeEventoDeFoco Tipo { get; set; }
    [Required]
    public int Posicao { get; set; }
}