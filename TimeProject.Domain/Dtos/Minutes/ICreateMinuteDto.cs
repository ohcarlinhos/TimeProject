namespace TimeProject.Domain.Dtos.Minutes;

public interface ICreateMinuteDto
{
    int RecordId { get; set; }
    DateTime Date { get; set; }
    int Minutes { get; set; }
}