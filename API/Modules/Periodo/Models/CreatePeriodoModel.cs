namespace API.Modules.Periodo.Models;

public class CreatePeriodoModel
{
    public int RegistroId { get; set; }
    public DateTime Inicio { get; set; }
    public DateTime Fim { get; set; }
}