using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PomodoroAPI.Modules.RegistroDeTempo.Enums;
using PomodoroAPI.Modules.Usuario.Models;

namespace PomodoroAPI.Modules.RegistroDeTempo.Models;

[Table("eventos_dos_registros")]
public class EventoModel
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public virtual UsuarioModel? Usuario { get; set; }
    public int TempoFocadoId { get; set; }
    public DateTime DataDeRegistro { get; set; }
    public TipoDeEvento Tipo { get; set; }
    [Required]
    public int Posicao { get; set; }
}