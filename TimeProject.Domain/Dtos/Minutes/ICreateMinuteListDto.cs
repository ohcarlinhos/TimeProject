namespace TimeProject.Domain.Dtos.Minutes;

public interface ICreateMinuteListDto
{
    DateTime Date { get; set; }
    List<int> Minutes { get; set; }
}