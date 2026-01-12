namespace TimeProject.Domain.RemoveDependencies.Dtos.Period;

public interface ICreatePeriodDto
{
    int RecordId { get; set; }
    DateTime Start { get; set; }
    DateTime End { get; set; }
}