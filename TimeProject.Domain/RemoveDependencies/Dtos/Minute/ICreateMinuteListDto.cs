namespace TimeProject.Domain.RemoveDependencies.Dtos.Minute;

public interface ICreateMinuteListDto
{
    DateTime Date { get; set; }
    List<int> Minutes { get; set; }
}