namespace API.Modules.RegistroDeTempo.DTO;

public class PeriodoDeTempoDto
{
    public int Id { get; set; }
    public DateTime Inicio { get; set; }
    public DateTime Fim { get; set; }

    private TimeSpan Calc => Fim.Subtract(Inicio);

    public object Tempo => new
    {
        Segundos = Calc.Seconds,
        Minutos = Calc.Minutes,
        Horas = Calc.Hours,
        Dias = Calc.Days,
    };
}