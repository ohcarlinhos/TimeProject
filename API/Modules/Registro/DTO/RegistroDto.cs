using API.Modules.Categoria.Entities;
using API.Modules.TimePeriod.DTO;

namespace API.Modules.Registro.DTO;

public class RegistroDto
{
    public int Id { get; set; }
    public string? Descricao { get; set; }
    public int UsuarioId { get; set; }
    public string? CategoriaNome => Categoria?.Nome;
    public int? CategoriaId { get; set; }

    public List<TimePeriodDto> Periodos { get; set; }
    public DateTime? RegistroDate => Periodos.Count > 0 ? Periodos[0].Start : null;
    public int PeriodosCount => Periodos.Count;

    private TimeSpan PeriodosCalc
    {
        get
        {
            var total = new TimeSpan();
            return Periodos
                .Aggregate(total, (current, periodo) =>
                    current.Add(periodo.End.Subtract(periodo.Start)));
        }
    }

    private double Segundos => PeriodosCalc.Seconds;
    private double Minutos => PeriodosCalc.Minutes;
    private double Horas => PeriodosCalc.Hours;
    private double Dias => PeriodosCalc.Days;

    public string TempoFormatado
    {
        get
        {
            var tempoFormatado = "";
            if (Dias > 0)
                tempoFormatado += $"{Dias}d ";
            if (Horas > 0)
                tempoFormatado += $"{Horas}h ";
            if (Minutos > 0)
                tempoFormatado += $"{Minutos}m ";
            if (Segundos > 0)
                tempoFormatado += $"{Segundos}s ";

            return tempoFormatado.Trim();
        }
    }

    public object? Tempo =>
        Periodos.Count > 0
            ? new
            {
                Segundos,
                Minutos,
                Horas,
                Dias,
            }
            : null;

    public CategoriaEntity? Categoria { private get; set; }
}