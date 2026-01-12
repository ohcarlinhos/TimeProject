namespace TimeProject.Domain.RemoveDependencies.Dtos.Minute;

public interface ICreateMinuteDto
{
    int RecordId { get; set; }
    DateTime Date { get; set; }
    int Minutes { get; set; }
}