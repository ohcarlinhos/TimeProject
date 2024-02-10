using PomodoroAPI.Enums;

namespace PomodoroAPI.Models;

public class EventoDeFoco
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public virtual Usuario? Usuario { get; set; }
    public int TempoFocadoId { get; set; }
    public DateTime DataDeRegistro { get; set; }
    public TipoDeEventoDeFoco Tipo { get; set; }
    public int Posicao { get; set; }
}