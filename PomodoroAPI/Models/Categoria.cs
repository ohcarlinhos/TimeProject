namespace PomodoroAPI.Models;

public class Categoria
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public int Nome { get; set; }
    public virtual Usuario? Usuario { get; set; }
}