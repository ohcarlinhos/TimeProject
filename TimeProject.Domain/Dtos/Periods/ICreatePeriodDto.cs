namespace TimeProject.Domain.Dtos.Periods;

public interface ICreatePeriodDto
{
    int RecordId { get; set; }
    DateTime Start { get; set; }
    DateTime End { get; set; }
}