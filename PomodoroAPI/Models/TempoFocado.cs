namespace PomodoroAPI.Models;

public class TempoFocado
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public virtual Usuario? Usuario { get; set; }
    public int CategoriaId { get; set; }
    public virtual Categoria? Categoria { get; set; }
    public string? Titulo { get; set; }
    public DateTime DataDeRegistro { get; set; }
    public EventoDeFoco[] Eventos { get; set; }
}